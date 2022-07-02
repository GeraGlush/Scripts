using System.Collections;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    [SerializeField]
    private float _energyExpenses;
    [SerializeField]
    private Vector2 _damage;
    [SerializeField]
    private float power;

    private PlayerEnergy _playerEnergy_cs;
    private PlayerInput _playerInput_cs;

    public Transform spawnPoint;
    public GameObject fireBall;

    private bool attack;

    private void Start()
    {
        _playerEnergy_cs = GetComponent<PlayerEnergy>();
        _playerInput_cs = GetComponent<PlayerInput>();
    }


    void Update()
    {
        if (_playerInput_cs.GetSpecialAttackKeyDown() && !attack)
        {
            if (_playerEnergy_cs.GetEnergy() > _energyExpenses)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        GetComponent<IAnimation>().SetTrigger("SpecialAttack");
        attack = true;
        GetComponent<PlayerMove>().enabled = false;
        yield return new WaitForSeconds(2f);

        GameObject spawnedFireBall = Instantiate(fireBall, transform.position, transform.rotation);

        Explosion explosion = spawnedFireBall.GetComponent<Explosion>();
        explosion.warSide = GetComponent<WarSideManager>().GetWarSide();
        explosion.damage = _damage;
        explosion.power = power;

        _playerEnergy_cs.Lose(_energyExpenses);
        GetComponent<PlayerMove>().enabled = true;
        attack = false;
    }
}
