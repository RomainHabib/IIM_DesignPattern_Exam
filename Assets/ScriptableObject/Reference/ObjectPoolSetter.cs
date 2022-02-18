using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Reference/ObjectPoolReference")]
public class ObjectPoolSetter : MonoBehaviour
{
    [SerializeField] ObjectPooling _pooling;
    [SerializeField] ObjectPoolReference _poolRef;

    void Awake()
    {
        (_poolRef as IReferenceSetter<ObjectPooling>).SetInstance(_pooling);
    }
}
