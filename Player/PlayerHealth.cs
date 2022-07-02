using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class PlayerHealth : BotHealth
    {
        public PlayerBar healthBar;
        public float healthRegeneration;

        private void Start()
        {
            StartCoroutine(Regeneration());
        }

        public virtual void ApplyDamage(float amount)
        {
            if (TryGetComponent(out IAnimation animation))
            {
                animation.SetTrigger("TakeDamage");
            }

            GetComponent<AudioPlayer>().TakeDamageSoursePlay();
            _health.Lose(amount);

            FindObjectOfType<Menu>().ShowRestartMenu();
            SetHealthBar();
        }

        private void SetHealthBar()
        {
            healthBar.SetBarValue(_health.Current, _maxHealth);
        }


        private IEnumerator Regeneration()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _health.Restore(healthRegeneration);
                SetHealthBar();
            }
        }
    }
}