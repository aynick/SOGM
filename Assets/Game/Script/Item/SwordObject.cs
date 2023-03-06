using System;
using UnityEngine;

namespace Script
{
    public class SwordObject : ItemObject
    {
        private int dmg;
        public float attackRate;
        [SerializeField] private Animator _animator;
        private bool canAttack =true;

        public void Attack()
        {
            _animator.SetTrigger("Attack");
            canAttack = true;
        }
        
        public void SetSwordData(SwordData swordData)
        {
            dmg = swordData.dmg;
            attackRate = swordData.attackRate;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable idamagable)) 
            {
                if (canAttack)
                {
                    idamagable.ApplyDamage(dmg);
                }
            }
        }
    }
}