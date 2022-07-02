using UnityEngine;

public class ArcherAnimation : MonoBehaviour, IAnimation
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Vector3 stringInTheDischargedState;
    private ArcherAttack archerAttack_cs;
    public GameObject arrowToAnimation;

    public Transform stringKeep;
    public Transform bowString;

    public bool grapString;
    public bool startDrawArrow;


    private void Start()
    {
        archerAttack_cs = GetComponent<ArcherAttack>();
    }

    public void SetTrigger(string name)
    {
        _animator.SetTrigger(name);
    }

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void ResetArrowDraw()
    {
        startDrawArrow = false;
        arrowToAnimation.SetActive(false);
        startDrawArrow = false;
        grapString = false;
    }

    public void DrawArrowAnimation()
    {
        if (!archerAttack_cs.arrowIsDraw)
        {
            if (!startDrawArrow)
            {
                startDrawArrow = true;
                SetTrigger("DrawArrow");
                StopCoroutine(BowAndArrowAnimation());
                StartCoroutine(BowAndArrowAnimation());
            }

            if (grapString)
            {
                bowString.position = stringKeep.position;
            }
            else
            {
                bowString.localPosition = stringInTheDischargedState;
            }
        }

    }

    public void ShootAnimation()
    {
        SetTrigger("Shoot");
        arrowToAnimation.SetActive(false);
        startDrawArrow = false;
        grapString = false;
    }

    private void ActiveObjectToAnimation(bool active)
    {
        arrowToAnimation.gameObject.SetActive(active);
    }

    public System.Collections.IEnumerator BowAndArrowAnimation()
    {
        arrowToAnimation.SetActive(false);
        yield return new WaitForSeconds(1.3f);
        arrowToAnimation.SetActive(true);
        yield return new WaitForSeconds(0.4f);

        grapString = true;
        yield return new WaitForSeconds(0.3f);
        archerAttack_cs.arrowIsDraw = true;
    }
}
