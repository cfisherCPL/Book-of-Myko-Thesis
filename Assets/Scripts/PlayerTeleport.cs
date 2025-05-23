using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private DayTimeManager timeController;
    private bool changeTime;

    public int currentTime;

    AudioManager audioManager;

    private bool makeDark;
    private bool makeCurrentTime;

    [SerializeField] GameObject globalDaylight;
    [SerializeField] public Light2D secondlight;

    private FadeInOut fade;

    private NPC_Activator NPC_Activator;

    public bool preventInput;

    void Awake()
    {
        changeTime = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        fade = FindObjectOfType<FadeInOut>();
        NPC_Activator = FindObjectOfType<NPC_Activator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !preventInput)
        {
            if (currentTeleporter != null)
            {
                //move the player to the target location
                StartCoroutine(ChangeLocation());

                //wipe current area's mushrooms
                if (currentTeleporter.GetComponent<Teleporter>().clearsMushrooms)
                {
                    GameObject spawnerAccess = currentTeleporter.GetComponent<Teleporter>().GetMushSpawner();
                    spawnerAccess.GetComponent<Mushroom_Spawner_Outside>().clearSpawnedMushrooms();

                }

                //play a soundeffect if it is supposed to
                //wipe current area's mushrooms
                if (currentTeleporter.GetComponent<Teleporter>().playsSFX)
                {
                    audioManager.PlaySFX(currentTeleporter.GetComponent<Teleporter>().clipToPlay);
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
                                                              

                if (currentTeleporter.GetComponent<Teleporter>().stopsMusic)
                {
                    audioManager.StopMusic();
                }
                else if (!audioManager.musicSource.isPlaying)
                {
                    int numClips = currentTeleporter.GetComponent<Teleporter>().musicToStart.Length;

                    audioManager.PlayMusic(currentTeleporter.GetComponent<Teleporter>().musicToStart[(int)Random.Range(0,numClips)]);
                }

                if (makeDark)
                {
                    globalDaylight.SetActive(false);
                    secondlight.gameObject.SetActive(true);
                }

                if (makeCurrentTime)
                {
                    globalDaylight.SetActive(true);
                    secondlight.gameObject.SetActive(false);
                }

                NPC_Activator.ActivateDeactivateAll();

              
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            changeTime = currentTeleporter.GetComponent<Teleporter>().GetChangesTime();
            makeDark = currentTeleporter.GetComponent<Teleporter>().makesDark;
            makeCurrentTime = currentTeleporter.GetComponent<Teleporter>().makeCurrentTime;

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
                makeDark = false;
                currentTime = 69;
            }
        }
    }


    public IEnumerator ChangeLocation()
    {
        preventInput = true;
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        fade.FadeOut();
        yield return new WaitForSeconds(0.3f);
        preventInput = false;
    }
}
