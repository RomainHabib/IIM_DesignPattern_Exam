using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
   [SerializeField] private PlayerReference player;
   [SerializeField] private Slider healthSlider;
   
   // If the player take damage, the slider is updated 
   void UpdateHealthSliderDamage(int _) => healthSlider.value = ((float) player.Instance.Health.CurrentHealth / player.Instance.Health.MaxHealth);
   
   // If the player get healed, the slider is updated 
   void UpdateHealthSliderHeal() => healthSlider.value = ((float) player.Instance.Health.CurrentHealth / player.Instance.Health.MaxHealth);

   private void Start()
   {
      player.Instance.Health.OnDamage += UpdateHealthSliderDamage;
      player.Instance.Health.OnHeal += UpdateHealthSliderHeal;
   }

   private void OnDestroy()
   {
      player.Instance.Health.OnDamage -= UpdateHealthSliderDamage;
      player.Instance.Health.OnHeal -= UpdateHealthSliderHeal;
   }

   private void playerOnHealthChange(int obj)
   {
      UpdateHealthSliderDamage(obj);
   }
}
