using System;
using UnityEngine;

public class Sword : Weapon
{
    public float attackTypeDamage;

    public override void Detriment(IDamageable health_cs)
    {
        health_cs.ApplyDamage(Damage + attackTypeDamage);

        if (TryGetComponent(out Collider collider))
            collider.enabled = false;
    }
}