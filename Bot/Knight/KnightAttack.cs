using UnityEngine;

public class KnightAttack : MonoBehaviour, IAttack
{
    public float attackDistanse;    
    private KnightAttackType[] _attackTypes_cs;

    public GameObject weapon;

    [SerializeField]
    private GameObject _attackTypeObject;

    
    private float timeToMakeAttack;
    private AudioPlayer _botAudio_cs;
    private KnightAnimation _knightAnimation_cs;

    
    void Start()
    {
        _botAudio_cs = GetComponent<AudioPlayer>();
        _knightAnimation_cs = GetComponent<KnightAnimation>();
        _attackTypes_cs = _attackTypeObject.GetComponents<KnightAttackType>();
    }

    public void Attack()
    {
        if (timeToMakeAttack < Time.time || timeToMakeAttack == 0)
        {
            _botAudio_cs.AttackSoursePlay();
            KnightAttackType currentAttackType = _attackTypes_cs[Random.Range(0, _attackTypes_cs.Length)];
            currentAttackType.Attack(_knightAnimation_cs, weapon);
            weapon.GetComponent<BoxCollider>().enabled = true;
            timeToMakeAttack = Time.time + 2;
        }
    }

    public bool CanAttack(Transform objectToCheak)
    {
        if (GetComponent<BotSee>().DistanseToObject(objectToCheak, attackDistanse))
        {
            return true;
        }
        return false;
    }

    public Weapon GetWeapon()
    {
        return weapon.GetComponent<Sword>();
    }
}
