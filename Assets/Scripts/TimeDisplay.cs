using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    private TMP_Text _timeText;

    public TimeOfDay currentTimeOfDay;

    public string[] TimeNames = new string[5]
     {
        "Morning", 
        "Daytime", 
        "Evening", 
        "Night", 
        "Midnight" 
     };

private string timeToString;


   void Awake()
   {
     _timeText = GetComponent<TMP_Text>();

   }

   void Start()
   {
      timeToString = TimeNames[currentTimeOfDay.currentTimeOfDay];
     _timeText.text = $" {timeToString}";   
     
     }

   void Update()
   {
      timeToString = TimeNames[currentTimeOfDay.currentTimeOfDay];
     _timeText.text = $" {timeToString}";
   }

}
