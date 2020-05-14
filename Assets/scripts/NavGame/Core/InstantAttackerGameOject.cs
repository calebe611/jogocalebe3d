using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{

    public class InstantAttackerGameOject : AttackGameObject
    {
        protected override void Attack(DamageableGameObject target)
        {
            target.TakeDamage(ofenseStats.damage);
            if (onAttackStrike != null)
            {
                onAttackStrike(target.damageTransform.position);
            }
        }
    }
}
