using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeofDay : MonoBehaviour
{
    private DayTimeManager timeController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DayTimeManager.Instance.nextTime();
        }
    }
}
