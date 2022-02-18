using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if there is a collectable component, if true, do ; else, ignore
        if (collision.GetComponent<ICollectable>() != null)
        {
            // if the player collide with an object collectable, launch the Collect Function of the object
            collision.GetComponent<ICollectable>()?.Collect();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if there is a collectable component, if true, do ; else, ignore
        if (collision.collider.GetComponent<ICollectable>() != null)
        {
            // if the player collide with an object collectable, launch the Collect Function of the object
            collision.collider.GetComponent<ICollectable>()?.Collect();
        }
    }
}
