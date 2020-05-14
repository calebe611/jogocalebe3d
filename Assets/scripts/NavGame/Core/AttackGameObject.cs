using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;
using UnityEngine.AI;

namespace NavGame.Core
{
    [RequireComponent(typeof(NavMeshAgent))]

    public abstract class AttackGameObject : TouchableGameObject
    {
        public OfenseStats ofenseStats;

        public float attackRange = 4f;
         public float attackDelay = 0.5f;
         public Transform castTransform;
        public string[] enemyLayers;

        [SerializeField]

        protected List<DamageableGameObject> enemiesToAttack = new List<DamageableGameObject>();
         protected NavMeshAgent agent;
        float cooldonw = 0f;
        LayerMask enemyMask;
        public OnAttackStarEvent onAttackStart;
        public OnAttackCastEvent onAttackCast;
        public OnAttackStrikeEvent onAttackStrike;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            enemyMask = LayerMask.GetMask(enemyLayers);
            if(castTransform == null)
            {
                castTransform = transform;
            }
        }

        protected virtual void Update()
        {
            DecreaseAttackCooldonw();
            UpdateAttack();
        }
        protected virtual void UpdateAttack()
        {
            if (enemiesToAttack.Count > 0)
            {
                agent.SetDestination(enemiesToAttack[0].gameObject.transform.position);
                if(IsInRange(enemiesToAttack[0].gameObject.transform.position))
                {
                    agent.ResetPath();
                    FaceObjectFrame(enemiesToAttack[0].gameObject.transform);
                    AttackOnCooldonw(enemiesToAttack[0]);
                }
            }
        }

        public void AttackOnCooldonw(DamageableGameObject target)
        {
            if (cooldonw <= 0f)
            {
                cooldonw = 1f / ofenseStats.attackSpeed;
                if(onAttackStart != null)
                {
                    onAttackStart();
                }
               StartCoroutine( AttackAfterDelay(target, attackDelay));
            }

        }

       IEnumerator AttackAfterDelay(DamageableGameObject target, float delay )
        {
            yield return new WaitForSeconds( delay);
            if( target != null)
            {
                if( onAttackCast != null)
                {
                    onAttackCast(castTransform.position);
                }
                 Attack(target);
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
                    obj.onDied += () => { enemiesToAttack.Remove(obj); };
                }

            }
        }

        void OnTriggerExit(Collider other)
        {
            if (enemyMask.Contains(other.gameObject.layer))
            {
                DamageableGameObject obj = other.transform.parent.GetComponent<DamageableGameObject>();
                enemiesToAttack.Remove(obj);
            }
        }

        public bool IsInRange(Vector3 point)
        {
            float distance = Vector3.Distance(transform.position, point);
            return distance <= attackRange;
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
        protected abstract void Attack(DamageableGameObject target);
    } 
}