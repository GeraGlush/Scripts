using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour, IAttack
{
    private ArcherAnimation _archerAnimation_cs;
    private AudioPlayer _botAudio_cs;

    [SerializeField]
    private Bow bow;

    private float _timeToNextShoot;

    public Vector2Int randomDamageValues;
    public float shootDistanse;
    public bool arrowIsDraw;


    private void Start()
    {
        bow.Damage = Random.Range(randomDamageValues.x, randomDamageValues.y);
       _archerAnimation_cs = GetComponent<ArcherAnimation>();
       _botAudio_cs = GetComponent<AudioPlayer>();
    }

    public void Attack(Transform attackTarget)
    {
        if (arrowIsDraw)
        {
            if (Time.time > _timeToNextShoot || _timeToNextShoot == 0f)
            {
                bow.Shoot(attackTarget);
                _botAudio_cs.ShootoursePlay();

                arrowIsDraw = false;
                _archerAnimation_cs.ShootAnimation();

                _timeToNextShoot = Time.time + 4f;
            }
        }
    }

    public void Attack()
    {
        if (arrowIsDraw)
        {
            if (Time.time > _timeToNextShoot || _timeToNextShoot == 0f)
            {
                bow.Shoot();
                _botAudio_cs.ShootoursePlay();

                arrowIsDraw = false;
                _archerAnimation_cs.ShootAnimation();

                _timeToNextShoot = Time.time + 4f;
            }
        }
    }

    public void DrawArrow()
    {
        _archerAnimation_cs.DrawArrowAnimation();
        _botAudio_cs.bowStringAudio.Play();
    }

    public bool CanAttack(Transform objectToAttack)
    {
        if (GetComponent<BotSee>().DistanseToObject(objectToAttack, shootDistanse))
        {
            return true;
        }
        return false;
    }

    public Weapon GetWeapon()
    {
        return bow;
    }
}
