using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackType : KnightAttackType
{
    [SerializeField] private float energyExpenses;
    public PlayerEnergy playerEnergy_cs;

    public override void Attack(KnightAnimation knightAnimation_cs, GameObject weapon)
    {
        knightAnimation_cs.SetTrigger(triggerAnimationTime);

        if (weapon.GetComponent<Weapon>() is Sword)
            weapon.GetComponent<Sword>().attackTypeDamage = damage;
        if (playerEnergy_cs != null)
            playerEnergy_cs.Lose(energyExpenses);
    }
}
