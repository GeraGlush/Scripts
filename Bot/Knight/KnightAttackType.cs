using UnityEngine;

public class KnightAttackType : MonoBehaviour
{
    public string triggerAnimationTime;
    public int damage;


    public virtual void Attack(KnightAnimation knightAnimation_cs, GameObject weapon)
    {
        knightAnimation_cs.SetTrigger(triggerAnimationTime);

        if (weapon.GetComponent<Weapon>() is Sword)
            weapon.GetComponent<Sword>().attackTypeDamage = damage;
    }

}
