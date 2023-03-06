using System;
using System.Collections.Generic;
using System.Linq;
using Script;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Script
{
    public class MeleeEnemyBehavior : EnemyBehavior , IStateSwitcher , IDamagable
    {
        [SerializeField] private int hp;
        private List<StateBase> _allStates;
        private StateBase _currentState;
        [SerializeField] private float speed;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator _animator;
        [SerializeField] private float attackRate;
        private EnemyStats _enemyStats;
        [SerializeField] private GameObject particle;

        private void Start()
        {
            _enemyStats = new EnemyStats(hp);
            _allStates = new List<StateBase>()
            {
                new MeleeMoveState(this,agent,transform,speed,_animator),
                new MeleeIdleState(this,agent,transform),
                new MeleeAttackState(this,_animator,attackRate,transform)
            };
            _currentState = _allStates[0];
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void Switch<T>() where T : StateBase
        {
            var s = _allStates.FirstOrDefault(s => s is T);
            if (s == null) return;
            _currentState.Exit();
            _currentState = s;
            _currentState.Enter();
        }

        public void ApplyDamage(int dmg)
        {
            if ((_enemyStats.hp - dmg) <= 0 )
                Destroy(gameObject);
            _enemyStats.hp -= dmg;
        }

        private void OnDestroy()
        {
            if (gameObject.scene.isLoaded)
            {
                var part = Instantiate(particle,transform.position,Quaternion.identity);
                part.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }
}