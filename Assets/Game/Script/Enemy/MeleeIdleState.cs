using Script;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Script
{
    public class MeleeIdleState : StateBase
    {
        private NavMeshAgent _agent;
        private Transform _transform;
        private IStateSwitcher _switcher;
        private Vector3 dir = Vector3.zero;
        private float time;
        private float cd = 1;
        public MeleeIdleState(IStateSwitcher switcher,NavMeshAgent agent,Transform transform)
        {
            _switcher = switcher;
            _agent = agent;
            _transform = transform;
        }
        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
            if (Vector3.Distance(_transform.position , PlayerBehavior.pos) < 30) _switcher.Switch<MeleeMoveState>();
            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                dir = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
                time = cd;
            }

            _agent.SetDestination(_transform.position + dir);
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }
    }
}