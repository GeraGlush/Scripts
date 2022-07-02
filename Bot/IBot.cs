using UnityEngine;

public interface IMove
{
    void SetTarget(Vector3 targetToSet);
    void RotateToAttackPosition(Vector3 target);

    Vector3 lastPositionTarget { get; set; }
    Transform mainTarget { get; }
}

public interface IMoveWithOutTarget
{
    void RandomMove();
}

public interface IAttack
{
    bool CanAttack(Transform objectToAttack);
    Weapon GetWeapon();
    void Attack();
}

public interface IBrain
{ 
    void SetTargetToAttack(Transform target);
}

public interface IAnimation
{
    void SetTrigger(string name);
    void SetBool(string name, bool value);
}