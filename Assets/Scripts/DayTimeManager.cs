using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayTimeManager : MonoBehaviour
{
   public UnityEvent dayChanged;
   public UnityEvent timeChanged;

   public DayOfWeek currentDay;
   public TimeOfDay currentTime;

   public static DayTimeManager Instance {get;private set;}

   private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void nextTime()
    {
        if (currentTime.currentTimeOfDay < 4)
        {
            currentTime.currentTimeOfDay += 1;
            Debug.Log("Time changed to next.");
        }
        else
        {
            currentTime.currentTimeOfDay = 0;
            Debug.Log("Time reset.");
        }
        
        timeChanged.Invoke();
        
    }

    public void nextDay()
    {
         if (currentDay.currentDay < 6)
        {
            currentDay.currentDay += 1;
            currentTime.currentTimeOfDay = 0;
            Debug.Log("Time reset.");
            Debug.Log("Day changed to next.");
        }
        else
        {
            currentDay.currentDay = 0;
            currentTime.currentTimeOfDay = 0;
            Debug.Log("Time reset.");
            Debug.Log("Day reset.");
        }

        dayChanged.Invoke();
        
    }


}
