using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;

namespace NavGame.Core
{


    public class CombatGameObject : DamageableGameObject
    {
        public OfenseStats ofenseStats;
        float cooldonw = 0f;

        public OnAttackHitEvent onAttackHit;
        
        protected virtual void Update()
        {
            DecreaseAttackCooldonw();
        }
        
        public void AttackOnCooldonw(DamageableGameObject target)
        {
            if( cooldonw <= 0f)
            {
                cooldonw = 1f / ofenseStats.attackSpeed;
                target.TakeDamage(ofenseStats.damage);
                if(onAttackHit != null)
                {
                    onAttackHit(target.transform.position);
                }
                
            }

        }
        void DecreaseAttackCooldonw()
        {
            if(cooldonw == 0f){
                return;
            }
            cooldonw -= Time.deltaTime;
            if(cooldonw < 0f)
            {
                cooldonw = 0f;
            }
        }

    }
}