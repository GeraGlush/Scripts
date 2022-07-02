using UnityEngine;
using Brain;

namespace Health
{
    public class Damageble : MonoBehaviour
    {
        public bool isShild;

        private void OnTriggerEnter(Collider otherCollider)
        {
            TryDamage(otherCollider);
        }

        private void OnColliderEnter(Collider otherCollider)
        {
            TryDamage(otherCollider);
        }

        private void TryDamage(Collider otherCollider)
        {
            if (TryGetComponent(out IDamageable damageable))
            {
                if (otherCollider.TryGetComponent(out Weapon weapon_cs))
                {
                    if (isShild)
                    {
                        weapon_cs.DisableCollider();
                        return;
                    }

                    if (weapon_cs.GetWeaponOwner().GetComponent<WarSideManager>() && GetComponent<WarSideManager>())
                    {
                        if (weapon_cs.GetWeaponOwner().GetComponent<WarSideManager>().GetWarSide() != GetComponent<WarSideManager>().GetWarSide())
                        {
                            weapon_cs.Detriment(damageable);
                            BloodPlay(weapon_cs);
                        }
                    }
                    
                    if (TryGetComponent(out IBrain brain))
                    {
                        if (brain is KnightBrain)
                        {
                            if (GetComponent<BotSee>().GetTarget() != null)
                            {
                                if (weapon_cs.GetWeaponOwner().GetComponent<WarSideManager>() && GetComponent<WarSideManager>())
                                {
                                    if (weapon_cs.GetWeaponOwner().GetComponent<WarSideManager>().GetWarSide() != GetComponent<WarSideManager>().GetWarSide())
                                    {
                                        GetComponent<BotSee>().SetTarget(weapon_cs.GetWeaponOwner().transform);
                                    }
                                }
                            }
                        }
                    }

                    if (TryGetComponent(out IAnimation animation))
                    {
                        animation.SetTrigger("TakeDamage");
                    }
                }
            }

        }
        private void BloodPlay(Weapon weapon_cs)
        {
            GameObject bloodPrefab = GetComponent<BotHealth>().bloodPrefab;
            Quaternion rotation = new Quaternion(-weapon_cs.transform.rotation.x, -weapon_cs.transform.rotation.y, -weapon_cs.transform.rotation.z, -weapon_cs.transform.rotation.w);
            GameObject blood = Instantiate(bloodPrefab, weapon_cs.bloodSpawnPoint.position, rotation);
            blood.GetComponent<Blood>().Play();
        }
    }
}