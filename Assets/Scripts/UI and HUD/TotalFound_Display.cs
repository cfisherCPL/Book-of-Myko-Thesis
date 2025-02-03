using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TotalFound_Display : MonoBehaviour
{

    private TMP_Text _FoundMushCount;
    public FoundMushroomTracker foundMushroomTracker;

    private int totalMushInGame;
    private int foundMushrooms;

    
    void Awake()
    {
        _FoundMushCount = GetComponent<TMP_Text>();
        CountMushrooms();

    }

    void Start()
    {
        CountMushrooms();
        _FoundMushCount.text = "Mushrooms Found: " + foundMushrooms.ToString() + " of " + totalMushInGame.ToString();
    }

    void Update()
    {
        CountMushrooms();
        _FoundMushCount.text = "Mushrooms Found: " + foundMushrooms.ToString() + " of " + totalMushInGame.ToString();
    }


    void CountMushrooms()
    {
        totalMushInGame = foundMushroomTracker.mushroomByItemNumber.Count;
        foundMushrooms = 0;
        foreach (bool entry in foundMushroomTracker.mushroomByItemNumber)
        {
            if (entry)
            {
                foundMushrooms++;
            }
        }
    }
}
