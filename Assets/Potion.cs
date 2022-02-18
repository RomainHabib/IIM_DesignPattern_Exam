using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, ICollectable, IPoolable
{
    [SerializeField] private PlayerReference player;
    [SerializeField] private int healthAmount;
    
    // Heal player, then destroy itself
    public void Collect()
    {
        Debug.Log($"Healing player with a potion of {healthAmount} hp");
        player.Instance.Health.Heal(healthAmount);
     
        ReturnToPool();
    }

    public void OnPooled()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
