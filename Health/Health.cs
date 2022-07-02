using System;
using UnityEngine;

namespace Health
{
    public class Health :  MonoBehaviour, IHealth, IFinal, IMutable<float>
    {
        public event Action Over;

        [SerializeField] private readonly float _max;
        private const float Min = 0;

        public Health(float max)
        {
            _max = max;
            Current = _max;
        }

        public float Current { get; private set; }

        public void Lose(float amount)
        {
            SetCurrent(Current - amount);
        }

        public void Restore(float amount)
        {
            if ((Current + amount) < _max)
            {
                SetCurrent(Current + amount);
            }
            else
            {
                SetCurrent(_max);
            }
        }

        private void SetCurrent(float amount)
        {
            Current = Mathf.Clamp(amount, Min, _max);

            if (Current == Min) Over?.Invoke();
        }

    }
}