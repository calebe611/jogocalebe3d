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
        public string[] enemyLayers;

        [SerializeField]

        protected List<DamageableGameObject> enemiesToAttack = new List<DamageableGameObject>();



        protected NavMeshAgent agent;
        float cooldonw = 0f;
        LayerMask enemyMask;

        public OnAttackHitEvent onAttackHit;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            enemyMask = LayerMask.GetMask(enemyLayers);
        }

        protected virtual void Update()
        {
            DecreaseAttackCooldonw();
        }

        public void AttackOnCooldonw(DamageableGameObject target)
        {
            if (cooldonw <= 0f)
            {
                cooldonw = 1f / ofenseStats.attackSpeed;
                target.TakeDamage(ofenseStats.damage);
                if (onAttackHit != null)
                {
                    onAttackHit(target.transform.position);
                }

            }

        }
        void DecreaseAttackCooldonw()
        {
            if (cooldonw == 0f)
            {
                return;
            }
            cooldonw -= Time.deltaTime;
            if (cooldonw < 0f)
            {
                cooldonw = 0f;
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (enemyMask.Contains(other.gameObject.layer))
            {
                DamageableGameObject obj = other.transform.parent.GetComponent<DamageableGameObject>();
                if (!enemiesToAttack.Contains(obj))
                {
                    enemiesToAttack.Add(obj);
                }

            }
        }
    }
}