﻿using UnityEngine;

namespace NavGame.Core
{
    // character eventes
    public delegate void OnAttackStarEvent();
    public delegate void OnAttackCastEvent(Vector3 castPoint);
    public delegate void OnAttackStrikeEvent(Vector3 strikePoint);
     public delegate void OnDamageTakenEvent(Vector3 strikePoint, int amount);
    public delegate void OnHealthChangedEvent( int maxHealth, int currentHealth);
    public delegate void OnDieEvent();

    // level events

    public delegate void OnActionSelectEvent(int actionIndex);
    public delegate void OnActionCancelEvent(int actionIndex);

}