using UnityEngine;

namespace Health
{
    public class BotHealth : MonoBehaviour, IDamageable
    {
        [SerializeField]
        protected int _maxHealth = 100;

        public GameObject bloodPrefab;

        protected Health _health;

        protected void Awake()
        {
            _health = new Health(_maxHealth);

            if (TryGetComponent(out HealthBotBar bar))
                bar.SetBar(_health.Current);
        }

        protected void OnEnable()
        {
            _health.Over += Die;
        }

        protected void OnDisable()
        {
            _health.Over -= Die;
        }

        public virtual void ApplyDamage(float amount)
        {
            if (TryGetComponent(out IAnimation animation))
            {
                animation.SetTrigger("TakeDamage");
            }

            if (TryGetComponent(out HealthBotBar bar))
                bar.SetBar(_health.Current);

            GetComponent<AudioPlayer>().TakeDamageSoursePlay();
            _health.Lose(amount);
        }

        protected void Die()
        {
            GetComponent<AudioPlayer>().DeadSoursePlay();

            if (TryGetComponent(out HealthBotBar bar))
                bar.DestroyBar();

            StartCoroutine(DeathAnimation());
        }


        private System.Collections.IEnumerator DeathAnimation()
        {
            GetComponent<IAnimation>().SetBool("Death", true);

            yield return new WaitForSeconds(2f);

            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<CharacterController>());
            Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
            Destroy(this);
            Destroy(gameObject);
        }
    }
}