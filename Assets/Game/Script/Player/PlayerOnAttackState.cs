using System;
using UnityEngine;

namespace Script
{
    public class PlayerOnAttackState : StateBase
    {
        private IStateSwitcher _switcher;
        private float attackRate;
        private Transform _hand;
        private SwordObject _swordObject;
        private float time;
        public PlayerOnAttackState(IStateSwitcher switcher,Transform hand)
        {
            _switcher = switcher;
            _hand = hand;
        }
        public override void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                _switcher.Switch<PlayerAttackState>();
            }
        }

        public override void FixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void Enter()
        {
            try
            { 
                _swordObject = _hand.GetChild(0).GetComponent<SwordObject>();
                _swordObject.Attack();
                attackRate = _swordObject.attackRate;
            }
            catch (Exception e)
            {
                _switcher.Switch<PlayerAttackState>();
            }
            time = attackRate;
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}