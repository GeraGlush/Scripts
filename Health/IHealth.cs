using System;

namespace Health
{
    public interface IHealth
    {
        void Lose(float amount);
        void Restore(float amount);
    }

    public interface IMutable<out T>
    {
        T Current { get; }
    }

    public interface IFinal
    {
        event Action Over;
    }
}

public interface IDamageable
{
    void ApplyDamage(float amount);
}


