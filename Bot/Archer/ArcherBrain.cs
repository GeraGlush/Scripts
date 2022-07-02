using UnityEngine;
using Health;

namespace Brain
{
    [RequireComponent(typeof(ArcherAttack))]
    public class ArcherBrain : BotBrain
    {
        private ArcherAttack _archerAttack_cs;
        private ArcherAnimation _archerAnimation_cs;


        private void Start()
        {
            _archerAttack_cs = GetComponent<ArcherAttack>();
            _archerAnimation_cs = GetComponent<ArcherAnimation>();
        }

        protected override void GoToTarget(Transform target)
        {
            DrawArrowAnimationReset();
            _move_cs.SetTarget(target.position);
        }

        protected override void Attack()
        {
            _move_cs.RotateToAttackPosition(_botsee_cs.GetTarget().position);

            _animation_cs.SetBool("Run", false);

            if (_archerAttack_cs.arrowIsDraw)
            {
                _archerAttack_cs.Attack(_botsee_cs.GetTarget());
            }
            else
            {
                _archerAttack_cs.DrawArrow();
            }
        }

        private void DrawArrowAnimationReset()
        {
            _archerAnimation_cs.ResetArrowDraw();
            _archerAttack_cs.arrowIsDraw = false;
            _botsee_cs.SetTarget(null);
            _archerAnimation_cs.arrowToAnimation.SetActive(false);
        }    
    }
}