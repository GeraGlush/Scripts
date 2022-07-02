using UnityEngine;

public class Bow : Weapon
{
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;

    public float powerShootToPlayerBow;
    public float angle;

    public void Shoot(Transform enemyTarget)
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation);

        Vector3 target = enemyTarget.position - (Vector3.down * 2f);
        Vector3 direction = BallisticVel(target, GetWeaponOwner().transform.position);

        arrow.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);

        Arrow arrow_cs = arrow.GetComponent<Arrow>();
        arrow_cs.weaponOwner = weaponOwner;
        arrow_cs.Damage = Damage;
    }

    public void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.transform.rotation);

        arrow.GetComponent<Rigidbody>().AddForce(powerShootToPlayerBow * GetWeaponOwner().transform.forward, ForceMode.Impulse);

        Arrow arrow_cs = arrow.GetComponent<Arrow>();
        arrow_cs.weaponOwner = weaponOwner;
        arrow_cs.Damage = Damage;
    }

    Vector3 BallisticVel(Vector3 target, Vector3 source)
    {
        var dir = target - source;
        var h = dir.y;
        dir.y = 0;  
        var dist = dir.magnitude;  // get horizontal distance
        var a = angle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences
        var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        var res = vel * dir.normalized;
        if (float.IsNaN(res.x)) res = new Vector3();
        return res;
    }
}
