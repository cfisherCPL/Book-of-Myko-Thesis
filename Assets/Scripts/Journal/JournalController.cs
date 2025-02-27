using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    public GameObject journalPanel; 
    void Start()
    {
        journalPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        journalPanel.SetActive(!journalPanel.activeSelf);

        
    }
}
