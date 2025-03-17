using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] public bool changesTime;
    [SerializeField] public bool clearsMushrooms;
    [SerializeField] public GameObject localMushroomSpawner;
    [SerializeField] public AudioClip musicToStart;
    [SerializeField] public bool stopsMusic;


    //teleporters to interior locations should be able to change global light
    [SerializeField] public bool makesDark;
    [SerializeField] public bool makeCurrentTime;

    public AudioManager audioManager;

    public GameObject GetMushSpawner()
    {
        return localMushroomSpawner;
    }

    public Transform GetDestination()
    {
        return destination;
    }

    public bool GetChangesTime()
    {
        return changesTime;
    }

    private void Awake()
    {
        popupText.gameObject.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        popupText.gameObject.SetActive(false);
    }
}
