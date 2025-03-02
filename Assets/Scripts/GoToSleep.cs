using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoToSleep : MonoBehaviour
{
    [SerializeField]
    private TMP_Text sleepTextPopUp;

    private bool sleepAllowed;

    private DayTimeManager dayOfWeek;
    [SerializeField]
    private AlreadySpawned spawnTracker;

    public AudioManager audioManager;

    [SerializeField] GameObject requestLetterBox;
    [SerializeField] GameObject confirmSavePanel;
    [SerializeField] GameObject confirmSleepPanel;


    //stamina deprecated as mechanic 11-19-24
    //private StaminaManager _stamina;


    private void Awake()
    {
        dayOfWeek = FindObjectOfType<DayTimeManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //_stamina = FindObjectOfType<StaminaManager>();
    }

    private void Start()
    {
        sleepTextPopUp.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (sleepAllowed && Input.GetKeyDown("e"))
        {
            if (dayOfWeek.currentTime.currentTimeOfDay != 4)
            {
                confirmSleepPanel.SetActive(true);
            }
            else
            {
                SleepUntilTomorrow();
            }
        }
        
                     
    }

    public void SleepUntilTomorrow()
    {
        dayOfWeek.nextDay();
            spawnTracker.alreadySpawned = false;
            audioManager.PlayAmbiance(audioManager.dayAmbiance);
            if (!audioManager.musicSource.isPlaying)
            {
                audioManager.PlayMusic(audioManager.titleMusic);
            }
            requestLetterBox.GetComponent<LetterRequests>().GenerateNewRequest();
            //_stamina.ResetStamina();

            confirmSavePanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sleepAllowed = true;
        sleepTextPopUp.gameObject.SetActive(true);

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        sleepAllowed = false;
        sleepTextPopUp.gameObject.SetActive(false);

    }



}
