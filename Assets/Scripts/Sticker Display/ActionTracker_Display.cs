using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionTracker_Display : MonoBehaviour
{
    [SerializeField] private TMP_Text textTMP;
    [SerializeField] public ActionTracker actionTracker;
    [SerializeField] public GameObject journalPanel;


    [SerializeField] public string displayText;

    void Start()
    {
        textTMP.text = displayText + $"{actionTracker.actionCount}";
    }

    void Update()
    {
        if (journalPanel.activeSelf)
        {
            textTMP.text = displayText + $"{actionTracker.actionCount}";
        }
    }
}
