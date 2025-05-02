using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour
{
    public GameObject journalPanel;
    public GameObject dialoguePanel;

    AudioManager audioManager;

    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;
    [SerializeField] AudioClip changeSound;

    void Start()
    {
        journalPanel.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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

    public void ChangeTabSound()
    {
        audioManager.PlaySFX(changeSound);
    }

    public void TogglePanel()
    {
        //journalPanel.SetActive(!journalPanel.activeSelf);

        //updated to have sound 5-2-25
        if (journalPanel != null)
        {
            if (!journalPanel.activeSelf)
            {
                journalPanel.SetActive(true);
                
                audioManager.PlaySFX(openSound);
            }
            else
            {
                journalPanel.SetActive(false);
         
                audioManager.PlaySFX(closeSound);
            }
        }

    }
}
