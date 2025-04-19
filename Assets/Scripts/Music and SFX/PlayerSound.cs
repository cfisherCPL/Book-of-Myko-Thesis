using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] grassStepSounds;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void playGrassStep()
    {
        AudioClip clip = grassStepSounds[(int)Random.Range(0, grassStepSounds.Length)];
        audioSource.clip = clip;
        audioSource.volume = Random.Range(0.08f, 0.15f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
