using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    public float power;

    public Vector2 damage;
    public WarSide warSide;


    private void Start()
    {
        Discarding();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health.BotHealth health_cs))
        {
            if (warSide != other.gameObject.GetComponent<WarSideManager>().GetWarSide())
            {
                health_cs.ApplyDamage(Random.Range(damage.x, damage.y));
            }
        }
    }

    private void Discarding()
    {
        Rigidbody[] rbs = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            if (Vector3.Distance(transform.position, rb.transform.position) < radius)
            {
                Vector3 dir = rb.transform.position - transform.position;
                rb.AddForce(dir.normalized * power * (radius - Vector3.Distance(transform.position, rb.transform.position)), ForceMode.Impulse);
            }
        }
    }
}
