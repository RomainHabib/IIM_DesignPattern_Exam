using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for objects that can be in a pool (bullets, potions)
public interface IPoolable
{
    void OnPooled();
    void ReturnToPool();
}
