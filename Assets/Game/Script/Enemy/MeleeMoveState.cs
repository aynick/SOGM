using Script;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Script
{
    public class MeleeMoveState : StateBase
    {
        private IStateSwitcher _switcher;
        private NavMeshAgent _agent;
        private Transform _transform;
        private Animator _animator;
        public MeleeMoveState(IStateSwitcher switcher,NavMeshAgent agent,Transform transform, float speed,Animator animator)
        {
            _animator = animator;
            _switcher = switcher;
            _agent = agent;
            _transform = transform;
        }
        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            if (Vector3.Distance(_transform.position,PlayerBehavior.pos) > 30) _switcher.Switch<MeleeIdleState>();
            if (Vector3.Distance(_transform.position,PlayerBehavior.pos) < 7) _switcher.Switch<MeleeAttackState>(); 
            else
            {
                _agent.SetDestination(PlayerBehavior.pos);
                Debug.Log("MOVE");
            }
        }

        public override void Enter()
        {
            _animator.SetBool("Move" ,true);
        }

        public override void Exit()
        {
            _animator.SetBool("Move" ,false);
        }
    }
}