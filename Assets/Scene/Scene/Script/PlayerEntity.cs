using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;

    [SerializeField] ControlShakeReference _controlShake;

    public Health Health => _health;

    private void Awake()
    {
        // Listen the damage event from player's health and launch a screen shake when occurs 
        _health.OnDamage += ShakeScreen;
    }

    private void OnDestroy()
    {
        _health.OnDamage -= ShakeScreen;
    }

    private void ShakeScreen(int _)
    {
        _controlShake.Instance.LaunchScreenShake();
    }

}


