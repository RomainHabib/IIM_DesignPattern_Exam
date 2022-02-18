using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Reference/ControlShake")]
public class ControlShakeReferenceSetter : MonoBehaviour
{
    [SerializeField] ControlShake _shake;
    [SerializeField] ControlShakeReference _shakeRef;

    void Awake()
    {
        (_shakeRef as IReferenceSetter<ControlShake>).SetInstance(_shake);
    }
}
