using System;
using UnityEngine;

namespace Script
{
    public class PlayerAttackState : StateBase
    {
        private IStateSwitcher _switcher;
        public PlayerAttackState(IStateSwitcher switcher)
        {
            _switcher = switcher;
        }
        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _switcher.Switch<PlayerOnAttackState>();
            }
        }

        public override void FixedUpdate()
        {
        }

        public override void Enter()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                
            }
        }

        public override void Exit()
        {
        }
    }
}