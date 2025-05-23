using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

public class SaveData 
{
    public Vector3 playerPosition;

    public int daysPassed;
    public int trufflePets;
    public int requestsCompleted;
    public int convosHad;


    public int dayOfWeek;
    public int timeOfDay;
    public bool alreadySpawned;
    public List<bool> foundMushList;

    public Inventory saveBackpack;
    public Inventory saveStorage;
    public Inventory saveLetterBox;

    public JournalPanelSaveData journalPanel_common;
    public JournalPanelSaveData journalPanel_forest;
    public JournalPanelSaveData journalPanel_grasslands;
    public JournalPanelSaveData journalPanel_mountain;
    public JournalPanelSaveData journalPanel_special;

    public JournalPanelSaveData[] allPanels = new JournalPanelSaveData[5]; 

    public RequestSaveData requestSaveData;
    

}
