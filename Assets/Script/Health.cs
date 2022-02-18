using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    [SerializeField] UnityEvent _onDeath;

    // Propri�t�s
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public bool CanTakeDamage { get; set; }

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }
    public event UnityAction OnShield;
    public event UnityAction OnHeal;

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        CanTakeDamage = true;
        OnSpawn?.Invoke();
    }

    public void TakeDamage(int amount)
    {
        if (!CanTakeDamage) return;
        
        if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

        var tmp = CurrentHealth;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        var delta = CurrentHealth - tmp;
        OnDamage?.Invoke(delta);

        if(CurrentHealth <= 0)
        {
            _onDeath?.Invoke();
        }
    }

    public void Heal(int amount)
    {
        OnHeal?.Invoke();
        
        if (amount > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }
        else
        {
            CurrentHealth += amount;
        }
    }

    public void ApplyShield()
    {
        CanTakeDamage = !CanTakeDamage;
        OnShield?.Invoke();
    }

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }





}
