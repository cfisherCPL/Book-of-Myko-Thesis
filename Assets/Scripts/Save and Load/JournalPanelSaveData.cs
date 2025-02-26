using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

public class JournalPanelSaveData
{
    public List<JournalEntrySaveData> entryTracker;


    public JournalPanelSaveData(int itemsInPanel) 
    {
        entryTracker = new List<JournalEntrySaveData>(itemsInPanel);

        //UnityEngine.Debug.Log("Panel item size was " + itemsInPanel);
        //UnityEngine.Debug.Log("Size of entryTracker is " + entryTracker.Count);

        for (int i = 0; i < itemsInPanel; i++)
        {
            JournalEntrySaveData temp = new JournalEntrySaveData();
            entryTracker.Add(temp);
        }

        //UnityEngine.Debug.Log("Size of entryTracker is " + entryTracker.Count);

    }
}
