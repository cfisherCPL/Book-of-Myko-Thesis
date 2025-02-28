using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private DayTimeManager timeController;
    private bool changeTime;

    AudioManager audioManager;

    void Awake()
    {
        changeTime = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                //wipe current area's mushrooms
                if (currentTeleporter.GetComponent<Teleporter>().clearsMushrooms)
                {
                    GameObject spawnerAccess = currentTeleporter.GetComponent<Teleporter>().GetMushSpawner();
                    spawnerAccess.GetComponent<Mushroom_Spawner_Outside>().clearSpawnedMushrooms();

                }

                //change time to  next if that's what the teleporter does
                if (changeTime)
                {
                    DayTimeManager.Instance.nextTime();
                    if (DayTimeManager.Instance.currentTime.currentTimeOfDay >2)
                    {
                        audioManager.PlayAmbiance(audioManager.nightAmbiance);
                    }
                    else
                    {
                        audioManager.PlayAmbiance(audioManager.dayAmbiance);
                    }
                }

                //move the player to the target location
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

                

                if (currentTeleporter.GetComponent<Teleporter>().stopsMusic)
                {
                    audioManager.StopMusic();
                }
                else if (!audioManager.musicSource.isPlaying)
                {
                    audioManager.PlayMusic(currentTeleporter.GetComponent<Teleporter>().musicToStart);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            changeTime = currentTeleporter.GetComponent<Teleporter>().GetChangesTime();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                changeTime = false;
            }
        }
    }
}
