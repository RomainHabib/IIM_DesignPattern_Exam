using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerSetter : MonoBehaviour
{
    [SerializeField] LevelManager _level;
    [SerializeField] LevelManagerReference _levelRef;

    void Awake()
    {
        (_levelRef as IReferenceSetter<LevelManager>).SetInstance(_level);
    }
}
