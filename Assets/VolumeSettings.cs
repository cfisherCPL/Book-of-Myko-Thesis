using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider ambianceSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider footstepsSlider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetAmbianceVolume();
            SetFootstepsVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
        
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("musicVol", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetAmbianceVolume()
    {
        float volume = ambianceSlider.value;
        myMixer.SetFloat("ambianceVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("ambianceVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("sfxVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void SetFootstepsVolume()
    {
        float volume = footstepsSlider.value;
        myMixer.SetFloat("playerVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("playerVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        ambianceSlider.value = PlayerPrefs.GetFloat("ambianceVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        footstepsSlider.value = PlayerPrefs.GetFloat("playerVolume");

        SetAmbianceVolume();
        SetFootstepsVolume();
        SetMusicVolume();
        SetSFXVolume();
    }


}
