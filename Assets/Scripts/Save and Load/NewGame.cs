using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class NewGame : MonoBehaviour
{
    
    public FoundMushroomTracker mushTracker;
    public DayOfWeek dayOfWeek;
    public TimeOfDay timeOfDay;
    public AlreadySpawned spawnTracker;
    public NewGameTracker newGameTracker;
    public GameObject titleOverlay;
    public GameObject defaultPosition;
    public GameObject player;
    public SaveExistsTracker saveTracker;
    public GameObject continueButton;

    public void Start()
    {
        Invoke("hideMainUI", 0.002f);

        if (saveTracker.saveFileExists)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
    
    public void resetScriptables()
    {
        //set all found mushroom bits to false
        for(int i = 0; i < mushTracker.mushroomByItemNumber.Count; i++) 
        {
            mushTracker.mushroomByItemNumber[i] = false;
        }

        //set day of week to monday
        //stretchgoal: let player pick the start day? 2/26/28
        dayOfWeek.currentDay = 0;
        //set time of day to morning
        timeOfDay.currentTimeOfDay = 0;
        //set that mushrooms have already spawned to false
        spawnTracker.alreadySpawned = false;

        newGameTracker.isNewGame = true;

    }

    public void playerToDefault()
    {
        player.GetComponent<Transform>().position = defaultPosition.transform.position;
    }

    public void startGame()
    {
        this.gameObject.SetActive(false);

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadGame()
    {
        this.gameObject.SetActive(false);
        newGameTracker.isNewGame = false;
        
    }

    public void hideMainUI()
    {
        titleOverlay.SetActive(false);
    }

    public void Update()
    {
        if (gameObject.activeSelf)
        {
            if (saveTracker.saveFileExists)
            {
                continueButton.SetActive(true);
            }
            else
            {
                continueButton.SetActive(false);
            }
        }
    }


}
