using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DayDisplay : MonoBehaviour
{
   private TMP_Text _dayText;
   public DayOfWeek currentDayOfWeek;

    public string[] DayNames = new string[7]
     {
        "Monday", 
        "Tuesday", 
        "Wednesday", 
        "Thursday", 
        "Friday", 
        "Saturday",
        "Sunday"
     };

private string dayToString;

   void Awake()
   {
     _dayText = GetComponent<TMP_Text>(); 
    }

   void Start()
   {
      dayToString = DayNames[currentDayOfWeek.currentDay];
     _dayText.text = $" {dayToString}";   
    }

   void Update()
   {
      dayToString = DayNames[currentDayOfWeek.currentDay];
     _dayText.text = $" {dayToString}";
   }

}
