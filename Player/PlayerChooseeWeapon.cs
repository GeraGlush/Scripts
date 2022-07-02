using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooseeWeapon : MonoBehaviour
{
    public Weapon[] weapons;
    public Weapon activeWeapon;

    public GameObject arrowToAnimation;

    private PlayerInput _playerInput_cs;
    private ArcherAnimation _animation_cs;

    private void Start()
    {
        _playerInput_cs = GetComponent<PlayerInput>();
        _animation_cs = GetComponent<ArcherAnimation>();
    }

    void Update()
    {
        if (_playerInput_cs.GetButtonHideWeapons())
        {
            HideAllWeapons();
        }

        CheakTakeWeaponButton();
    }

    private void CheakTakeWeaponButton()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (_playerInput_cs.TakeWeaponButton(i))
            {
                StartCoroutine(TakeWeapon(weapons[i]));
                return;
            }
        }
    }

    private void HideAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            HideWeapon(weapon);
        }
    }

    private void HideWeapon(Weapon weaponToHide)
    {
        if (activeWeapon == weaponToHide)
        {
            HideWeaponAnimation(weaponToHide);
        }
        arrowToAnimation.SetActive(false);
        weaponToHide.gameObject.SetActive(false);
    }

    private System.Collections.IEnumerator TakeWeapon(Weapon weapon)
    {
        if (activeWeapon != null)
        { 
            if (weapon is Sword)
            {
               SetEnabledToAllScriptsKnight(false);

                _animation_cs.SetTrigger("DrawSwordBack");
                yield return new WaitForSeconds(0.8f);
            }
            else if (weapon is Bow)
            {
               SetEnabledToAllScriptsKnight(false);

                _animation_cs.SetTrigger("DrawBowBack");
                yield return new WaitForSeconds(1f);
            }

            HideAllWeapons();
        }
        weapon.gameObject.SetActive(true);

        if (weapon is Sword)
        {
            SetEnabledToAllScriptsKnight(true);

            _animation_cs.SetTrigger("DrawSword");
            yield return new WaitForSeconds(0.8f);
        }
        else if (weapon is Bow)
        {
            SetEnabledToAllScriptsArcher(true);

            _animation_cs.SetTrigger("DrawBow");
            yield return new WaitForSeconds(1f);
        }
        activeWeapon = weapon;
    }

    private System.Collections.IEnumerator HideWeaponAnimation(Weapon weapon)
    {
        if (weapon is Sword)
        {
            SetEnabledToAllScriptsKnight(false);

            _animation_cs.SetTrigger("DrawSwordBack");
            yield return new WaitForSeconds(0.8f);
        }
        else if (weapon is Bow)
        {
            SetEnabledToAllScriptsKnight(false);

            _animation_cs.SetTrigger("DrawBowBack");
            yield return new WaitForSeconds(1f);
        }

        activeWeapon = null;
        weapon.gameObject.SetActive(false);
    }

    private void SetEnabledToAllScriptsArcher(bool enabled)
    {
        if (TryGetComponent(out ArcherAttack a))
            return;


        ArcherAttack[] attacks_cs = GetComponents<ArcherAttack>();

        foreach (ArcherAttack attack in attacks_cs)
        {
            attack.enabled = enabled;
        }
    }

    private void SetEnabledToAllScriptsKnight(bool enabled)
    {
        if (TryGetComponent(out KnightAttack a))
            return;

        print("1");
        KnightAttack[] attacks_cs = GetComponents<KnightAttack>();

        foreach (KnightAttack attack in attacks_cs)
        {
            attack.enabled = enabled;
        }
    }
}
