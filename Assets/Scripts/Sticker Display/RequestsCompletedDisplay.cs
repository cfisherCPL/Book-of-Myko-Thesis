using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequestsCompletedDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text reqsCompletedText;
    [SerializeField] public LetterRequestTracker reqTracker;
    [SerializeField] public GameObject journalPanel;
    [SerializeField] public NewGameTracker newGameTracker;

    void Awake()
    {
    
        if (newGameTracker.isNewGame)
        {
            reqTracker.requestsCompleted = 0;
        }
    }

    void Start()
    {
        reqsCompletedText.text = $"Requests Completed: {reqTracker.requestsCompleted}";
    }

    void FixedUpdate()
    {
        if (journalPanel.activeSelf)
        {
            reqsCompletedText.text = $"Requests Completed: {reqTracker.requestsCompleted}";
        }
    }

}
