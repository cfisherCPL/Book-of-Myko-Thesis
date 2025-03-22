using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    public GameObject journalPanel;
    public GameObject dialoguePanel;

    void Start()
    {
        journalPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) | Input.GetKeyDown(KeyCode.Q) && !dialoguePanel.activeSelf)
        {
            TogglePanel();
        }

        if (dialoguePanel.activeSelf)
        {
            journalPanel.SetActive(false);
        }
    }

    public void TogglePanel()
    {
        journalPanel.SetActive(!journalPanel.activeSelf);

        
    }
}
