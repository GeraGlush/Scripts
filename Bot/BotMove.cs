using UnityEngine.AI;
using UnityEngine;
using Brain;

public class BotMove : MonoBehaviour, IMove, IMoveWithOutTarget
{
    private Vector3 target;
    public Vector3 lastPositionTarget { get; set; }

    public Transform mainTarget { get; set; }

    private NavMeshAgent _agent;
    private BotBrain _botBrain_cs;
    private BotSee _botSee_cs;
    private IAnimation _animation_cs;
    public RandomMoveTerritory _randomMoveTerritory_cs;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _botSee_cs = GetComponent<BotSee>();
        _botBrain_cs = GetComponent<BotBrain>();
        _animation_cs = GetComponent<IAnimation>();
    }

    private void Update()
    {
        if (_botBrain_cs.canMove)
        {
            if (_botSee_cs.GetTarget() != null)
            {
                SetTarget(_botSee_cs.GetTarget().position);
            }
        }
    }

    public void SetTarget(Vector3 targetToSet)
    {
        target = targetToSet;
        lastPositionTarget = targetToSet;

        GetComponent<AudioPlayer>().WalkAudioPlay();
        _agent.SetDestination(targetToSet);
        RotateToAttackPosition(targetToSet);
        _animation_cs.SetBool("Run", true);
    }

    public void RotateToAttackPosition(Vector3 rotateTarget)
    {
        Vector3 direction = rotateTarget - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 1 * Time.deltaTime);
    }

    public void RandomMove()
    {
        if (target == Vector3.zero)
        {
            if (_randomMoveTerritory_cs != null)
            {
                _animation_cs.SetBool("Run", true);
                SetTarget(_randomMoveTerritory_cs.randomMovePoints[Random.Range(0, _randomMoveTerritory_cs.randomMovePoints.Length)].position);
            }
            else
            {
                _animation_cs.SetBool("Run", false);
            }
        }
        else
        {
            if (transform.position.x == target.x && transform.position.z == target.z)
            {
                target = Vector3.zero;
                mainTarget = null;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RandomMoveTerritory>() != null)
        {
            _randomMoveTerritory_cs = other.gameObject.GetComponent<RandomMoveTerritory>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<RandomMoveTerritory>() != null)
        {
            _randomMoveTerritory_cs = null;
        }
    }
}
