using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, ICollectable
{
    [SerializeField]
    private UnityEvent OnCollect;
    
    public void Collect()
    {
        Debug.Log("key has been collected");
        // Launch the collect event
        OnCollect?.Invoke();
        Destroy(gameObject);
    }
}
