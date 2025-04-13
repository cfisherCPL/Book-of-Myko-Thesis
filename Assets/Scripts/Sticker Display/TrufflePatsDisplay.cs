using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrufflePatsDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text timesPatText;
    [SerializeField] public Truffle_Pets patsTracker;
    [SerializeField] public GameObject journalPanel;
    [SerializeField] public NewGameTracker newGameTracker;

    [SerializeField] public string displayText;

    void Awake()
    {
        //this might not work if you start a new game after already playing
        //move the reset responsibility into the SaveGame Manager 4-13-25
        if (newGameTracker.isNewGame)
        {
            patsTracker.ResetPets();
        }
    }

    void Start()
    {
        timesPatText.text = displayText+ $" {patsTracker.timesPet}";
    }

    void FixedUpdate()
    {
        if (journalPanel.activeSelf)
        {
            timesPatText.text = displayText + $" {patsTracker.timesPet}";
        }
    }
}
