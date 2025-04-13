using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DaysPassedDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textTMP;
    [SerializeField] public CentralTracker centralTracker;
    [SerializeField] public GameObject journalPanel;


    [SerializeField] public string displayText;

    void Start()
    {
        textTMP.text = displayText + $"{centralTracker.daysPassed}";
    }

    void Update()
    {
        if (journalPanel.activeSelf)
        {
            textTMP.text = displayText + $"{centralTracker.daysPassed}";
        }
    }
}
