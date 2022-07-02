using Health;
using UnityEngine;

namespace Brain
{
    public class KnightBrain : BotBrain
    {
        protected override void Attack()
        {
            _move_cs.RotateToAttackPosition(_botsee_cs.GetTarget().position);

            _animation_cs.SetBool("Run", false);
            _attack_cs.Attack();
        }
    }
}