using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    [SerializeField] private ObjectPoolReference objectPool;
    
    public void Touch(int power)
    {
        // Random to have one chance out of 3 of getting an object
        int chance = Random.Range(0, 3);

        if (chance == 0)
        {
            // Get an object from a pool
            var objectToSpawn = objectPool.Instance.GetObjectFromPool();
            objectToSpawn.transform.position = transform.position;
        }
        
        Destroy(gameObject);
    }
}
