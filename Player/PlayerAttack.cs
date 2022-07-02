using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public KnightAttack powerKnightAttack;
    public KnightAttack speedKnightAttack;
    public ArcherAttack shootArcherAttack;

    private PlayerInput _playerInput_cs;
    private PlayerChooseeWeapon _playerChooseeWeapon_cs;


    private void Start()
    {
        _playerInput_cs = GetComponent<PlayerInput>();
        _playerChooseeWeapon_cs = GetComponent<PlayerChooseeWeapon>();
    }

    public void Update()
    {
        if (_playerInput_cs.GetButtonAttack() && WeaponIsActive(speedKnightAttack))
            speedKnightAttack.Attack();
        if (_playerInput_cs.GetButtonAddicalAttack() && WeaponIsActive(powerKnightAttack))
            powerKnightAttack.Attack();
        if (WeaponIsActive(shootArcherAttack))
            ShootAttack();
    }

    public void ShootAttack()
    {
        if (shootArcherAttack.arrowIsDraw && _playerInput_cs.GetButtonAttack())
        {
            shootArcherAttack.Attack();
            GetComponent<PlayerChooseeWeapon>().enabled = true;
        }
        else if (_playerInput_cs.GetButtonAddicalAttack())
        {
            GetComponent<PlayerChooseeWeapon>().enabled = false;

            if (!shootArcherAttack.arrowIsDraw)
            {
                shootArcherAttack.DrawArrow();
            }
        }
    }

    private bool WeaponIsActive(IAttack attack)
    {
        return _playerChooseeWeapon_cs.activeWeapon == attack.GetWeapon();
    }
}
