using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]

public class SaveData 
{
    public Vector3 playerPosition;

    public int dayOfWeek;
    public int timeOfDay;
    public bool alreadySpawned;
    public List<bool> foundMushList;

    public Inventory saveBackpack;
    public Inventory saveStorage;



}
