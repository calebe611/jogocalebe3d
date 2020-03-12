using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;

namespace NavGame.Core
{


    public class CombatGameObject : DamageableGameObject
    {
        float cooldonw = 0f;
        
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
                AudioManager.instance.Play("enemy-hit", target.transform.position);
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