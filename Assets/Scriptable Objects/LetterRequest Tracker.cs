using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class LetterRequestTracker : ScriptableObject
{
    public int requestsCompleted;


    public void ResetCount()
    {
        requestsCompleted = 0;
    }
}
