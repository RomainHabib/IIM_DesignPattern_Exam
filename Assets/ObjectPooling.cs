using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn = null;
    [SerializeField] private int nbObjectInPool = 30;
    private List<GameObject> objectsInPool;
    
    private void Start()
    {
        objectsInPool = new List<GameObject>();

        GameObject objectSpawned;
        
        // Create a number X of items in the pool
        for (int i = 0; i < nbObjectInPool; i++)
        {
            objectSpawned = Instantiate(objectToSpawn, transform);
            objectSpawned.SetActive(false);
            objectsInPool.Add(objectSpawned);
        }
    }

    // return an unused object from the pool, if there is not, return a null object
    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < nbObjectInPool; i++)
        {
            if (!objectsInPool[i].activeInHierarchy)
            {
                objectsInPool[i].GetComponent<IPoolable>().OnPooled();
                return objectsInPool[i];
            }
        }

        return null;
    }
}
