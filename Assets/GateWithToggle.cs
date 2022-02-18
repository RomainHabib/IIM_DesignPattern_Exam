using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateWithToggle : MonoBehaviour
{
   [SerializeField] private int toggleNeededToUnlock;

   [SerializeField] private UnityEvent onToggleComplete;
   
   private int toggleIndex = 0;

   // Add +1 to the toggleIndex, check if the count is good
   public void AddAToggleOn()
   {
      toggleIndex++;

      if (toggleIndex == toggleNeededToUnlock)
      {
         // Execute the event
         onToggleComplete?.Invoke();
      }
   }

   public void AddAToggleOff()
   {
      toggleIndex--;
   }
}
