using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthProxy : MonoBehaviour, IHealth, ITouchable
{
    [SerializeField] Health _health;

    public int CurrentHealth => _health.CurrentHealth;

    public int MaxHealth => _health.MaxHealth;

    public bool IsDead => _health.IsDead;

    public bool CanTakeDamage
    {
        get => _health.CanTakeDamage;
    }

    public event UnityAction OnSpawn
    {
        add => _health.OnSpawn += value;
        remove => _health.OnSpawn -= value;
    }
    public event UnityAction<int> OnDamage
    {
        add => _health.OnDamage += value;
        remove => _health.OnDamage -= value;
    }
    public event UnityAction OnDeath
    {
        add => _health.OnDeath += value;
        remove => _health.OnDeath -= value;
    }

    public event UnityAction OnShield
    {
        add => _health.OnShield += value;
        remove => _health.OnShield -= value;
    }

    public event UnityAction OnHeal
    {
        add => _health.OnShield += value;
        remove => _health.OnShield -= value;
    }

    public void TakeDamage(int amount) => _health.TakeDamage(amount);
    public void ApplyShield() => _health.ApplyShield();
    public void Touch(int power) => _health.TakeDamage(power);

}
