using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;
using UnityEngine.AI;

namespace NavGame.Core
{
    [RequireComponent(typeof(NavMeshAgent))]

    public class AttackGameObject : TouchableGameObject
    {
        public OfenseStats ofenseStats;

         protected NavMeshAgent agent;
        float cooldonw = 0f;

        public OnAttackHitEvent onAttackHit;

        protected virtual void Awake()
        {
             agent = GetComponent<NavMeshAgent>();
        }
        
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