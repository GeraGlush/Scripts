using UnityEngine;
using Health;

namespace Brain
{
    public class BotBrain : MonoBehaviour, IBrain
    {
        public BotSee _botsee_cs;
        public BotMove _move_cs;

        public bool canMove;

        protected IHealth _health;
        protected IAttack _attack_cs;
        protected IAnimation _animation_cs;

        private void Awake()
        {
            _botsee_cs = GetComponent<BotSee>();
            _health = GetComponent<IHealth>();

            _move_cs = GetComponent<BotMove>();
            _attack_cs = GetComponent<IAttack>();
            _animation_cs = GetComponent<IAnimation>();
        }

        private void Update()
        {
            if (_botsee_cs.GetTarget() != null)
            {
                if (_attack_cs.CanAttack(_botsee_cs.GetTarget()))
                {
                    canMove = false;
                    Attack();
                }
                else
                {
                    canMove = true;
                    GoToTarget(_botsee_cs.GetTarget());
                }
            }
            else
            {
                if (_botsee_cs.GetTarget() != null)
                {
                    SetTargetToAttack(_botsee_cs.GetTarget());
                }
                else
                {
                    if (_move_cs.lastPositionTarget != Vector3.zero)
                    {
                        if (transform.position.x == _move_cs.lastPositionTarget.x && transform.position.z == _move_cs.lastPositionTarget.z)
                        {
                            _move_cs.lastPositionTarget = Vector3.zero;
                        }
                        else
                        {
                            _move_cs.SetTarget(_move_cs.lastPositionTarget);
                        }
                    }
                    else
                    {
                        if (_move_cs.mainTarget != null && _move_cs.mainTarget.position == Vector3.zero)
                        {
                            _move_cs.SetTarget(_move_cs.mainTarget.position);
                        }
                        else
                        {
                            _move_cs.RandomMove();
                        }
                    }
                }

                canMove = true;
            }
        }

        protected virtual void Attack()
        {
            _attack_cs.Attack();
        }

        protected virtual void GoToTarget(Transform target)
        {
            _move_cs.SetTarget(target.position);
        }

        public void SetTargetToAttack(Transform target)
        {
            _botsee_cs.SetTarget(target);
            _move_cs.SetTarget(target.position);
        }
    }
}
