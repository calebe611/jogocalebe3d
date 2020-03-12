using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;

namespace NavGame.Core
{


    public class CombatGameObject : DamageableGameObject
    {
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
                cooldonw = 1f / stats.attackSpeed;
                target.TakeDamage(stats.damage);
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