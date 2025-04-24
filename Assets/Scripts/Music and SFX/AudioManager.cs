using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
//using TMPro.EditorUtilities;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource ambianceSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("--------- Audio Clip ---------")]

    public AudioClip titleMusic;
    public AudioClip backgroundMusic;
    public AudioClip dayAmbiance;
    public AudioClip nightAmbiance;


    private void Start()
    {
        musicSource.clip = titleMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayAmbiance(AudioClip clip)
    {
        ambianceSource.clip = clip;
        ambianceSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public IEnumerator Fade( bool fadeIn, AudioSource source, float duration, float targetVolume)
    {
        if (!fadeIn)
        {
            double lengthOfSource = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)(lengthOfSource - duration));
        }

        float time = 0f;
        float startVol = source.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVolume, time/duration);
            yield return null;
        }

        yield break;
    }



    /*
     * 
     * guidance from https://www.youtube.com/watch?v=N8whM1GjH4w
     *
     * fade in and out: https://www.youtube.com/watch?v=kYGXGDjL5jM
     * 
     * 
    */
}
