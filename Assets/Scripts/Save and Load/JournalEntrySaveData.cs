using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

public class JournalEntrySaveData
{
    public int numberOfEntryFeatures;
    public List<bool> knownTracker;
    public List<bool> missingTracker;


    public JournalEntrySaveData() 
    {
        //how many features of data are shown for each mushroom in the journal?
        numberOfEntryFeatures = 12;

        knownTracker = new List<bool>();

        for (int i = 0; i < numberOfEntryFeatures; i++)
        {
            knownTracker.Add(false);
        }
        
        missingTracker = new List<bool>();

        for (int i = 0; i < numberOfEntryFeatures; i++)
        {
            missingTracker.Add(true);
        }
    }
}
