using UnityEngine;

namespace NavGame.Core
{
    // character eventes
    public delegate void OnAttackHitEvent(Vector3 position);
    public delegate void OnHealthChangedEvent( int maxHealth, int currentHealth);
    public delegate void OnDieEvent();
}