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



    public void markLetterAsRead()
    {
        endLetterRead = true;
    }


    public void ResetAll()
    {
        npcsMet = 0;
        conversations = 0;
        catsMet = 0;
        totalMushPicked = 0;
        totalMushPicked = 0;
        daysPassed = 0;
    }
}
