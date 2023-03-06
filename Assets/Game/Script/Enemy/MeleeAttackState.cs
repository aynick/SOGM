using Script;
using UnityEngine;

namespace Game.Script
{
    public class MeleeAttackState : StateBase
    {
        private IStateSwitcher _switcher;
        private Animator _animator;
        private float attackRate;
        private float time;
        private Transform _transform;
        
        public MeleeAttackState(IStateSwitcher switcher,Animator animator, float attackRate,Transform transform)
        {
            _transform = transform;
            _switcher = switcher;
            _animator = animator;
            this.attackRate = attackRate;
        }
        public override void Update()
        {
            if(Vector3.Distance(_transform.position, PlayerBehavior.pos) > 7) _switcher.Switch<MeleeMoveState>();
            time -= Time.deltaTime;
            if (time <= 0)
            {
                _animator.SetTrigger("Attack");
                time = attackRate;
            }
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}