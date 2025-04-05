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

    void Awake()
    {

        if (newGameTracker.isNewGame)
        {
            patsTracker.ResetPets();
        }
    }

    void Start()
    {
        timesPatText.text = $"Goodboy Truffle Pats: {patsTracker.timesPet}";
    }

    void FixedUpdate()
    {
        if (journalPanel.activeSelf)
        {
            timesPatText.text = $"Goodboy Truffle Pats: {patsTracker.timesPet}";
        }
    }
}
