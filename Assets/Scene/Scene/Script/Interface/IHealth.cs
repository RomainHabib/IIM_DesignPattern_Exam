using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHealth 
{
    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsDead { get; }
    
    bool CanTakeDamage { get;}

    event UnityAction OnSpawn;
    event UnityAction<int> OnDamage;
    event UnityAction OnDeath;

    event UnityAction OnShield;

    event UnityAction OnHeal;

    void TakeDamage(int amount);

    void ApplyShield();

}
