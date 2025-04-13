using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActionTracker : ScriptableObject
{
    public int actionCount;


    public void CountOnce()
    {
        actionCount = actionCount + 1;
    }

    public void ResetCount()
    {
        actionCount = 0;
    }
}
