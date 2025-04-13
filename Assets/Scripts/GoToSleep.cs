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
    [SerializeField] GameObject savedNoticePanel;

    [SerializeField] GameObject endGameLetter;
    [SerializeField] FoundMushroomTracker mushTracker;
    [SerializeField] GameObject cabinExit;
    [SerializeField] CentralTracker centralTracker;

    public bool preventInput;

    //stamina deprecated as mechanic 11-19-24
    //private StaminaManager _stamina;

    private FadeInOut fade;

    private void Awake()
    {
        dayOfWeek = FindObjectOfType<DayTimeManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //_stamina = FindObjectOfType<StaminaManager>();
    }

    private void Start()
    {
        sleepTextPopUp.gameObject.SetActive(false);
        fade = FindObjectOfType<FadeInOut>();
    }

    private void Update()
    {
        if (confirmSavePanel.activeSelf || confirmSleepPanel.activeSelf || savedNoticePanel.activeSelf)
        {
            preventInput = true;
            sleepTextPopUp.gameObject.SetActive(false);
        }
        else 
        { 
            preventInput = false; 
        }
        
        if (sleepAllowed && Input.GetKeyDown("e") && !preventInput)
        {
            if (dayOfWeek.currentTime.currentTimeOfDay != 4)
            {
                confirmSleepPanel.SetActive(true);
            }
            else
            {
                fade.FadeIn();
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

        if (CheckForComplete())
        {
            if (!centralTracker.endLetterRead)
            {
                cabinExit.SetActive(false);
                endGameLetter.SetActive(true);
            }
        }

        confirmSavePanel.SetActive(true);

        centralTracker.daysPassed += 1;
    }

    public bool CheckForComplete()
    {
        bool allMushFound = true;

        foreach (bool mush in mushTracker.mushroomByItemNumber)
        {
            if (!mush)
            {
                allMushFound = false;
                break;
            }
            
        }

        return allMushFound;
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

    public IEnumerator FadeToSleep()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }

}
