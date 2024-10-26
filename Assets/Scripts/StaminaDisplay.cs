using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class StaminaDisplay : MonoBehaviour
{
   private TMP_Text _staminaText;
   public PlayerStamina getStamina;

   void Awake()
   {
     _staminaText = GetComponent<TMP_Text>();
   }

   void Start()
   {
    _staminaText.text = $"Stamina Remaining: {getStamina.stamina}";
   }

   void FixedUpdate()
   {
        _staminaText.text = $"Stamina Remaining: {getStamina.stamina}";
    }


}

