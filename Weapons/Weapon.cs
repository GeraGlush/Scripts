using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weaponOwner;

    [SerializeField] protected float _damage;
    [SerializeField] protected bool _isPlayerWeapon;

    public Transform bloodSpawnPoint;

    private void Awake()
    {
        Damage = _damage;
        PlayerWeapon = _isPlayerWeapon;
    }

    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    public bool PlayerWeapon { get; set; } = false;

    public virtual void Detriment(IDamageable health_cs)
    {
        health_cs.ApplyDamage(Damage);
        DisableCollider();
    }

    public void DisableCollider()
    {
        if (TryGetComponent(out Collider collider))
            collider.enabled = false;
    }

    public GameObject GetWeaponOwner()
    {
        return weaponOwner;
    }
}
