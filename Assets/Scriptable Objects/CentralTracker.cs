using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]

public class CentralTracker : ScriptableObject
{

    public bool allMushFound;
    public bool endLetterRead;

    public int npcsMet;
    public int conversations;
    public int catsMet;
    public int totalMushPicked;
    public int daysPassed;

}
