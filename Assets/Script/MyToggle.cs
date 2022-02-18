using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un �v�nement pour les designers pour qu'ils puissent set la couleur du sprite eux m�me
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;

    public bool IsActive { get; private set; }

    public void Touch(int power)
    {
        IsActive = !IsActive;
        
        UnityEvent e = IsActive ? _onToggleOn : _onToggleOff;
        e.Invoke();
    }
}
