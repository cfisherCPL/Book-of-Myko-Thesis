using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextTimeOfDay : MonoBehaviour
{
    public UnityEvent goToNextTime;

    Collider2D trigger;

    private DayTimeManager timeController;

    private void Awake()
   {
        timeController = FindObjectOfType<DayTimeManager>();
        trigger = GetComponent<Collider2D>();

   }

       public void OnTriggerEnter2D(Collider2D other)
    {
        DayTimeManager.Instance.nextTime();
    }


}
