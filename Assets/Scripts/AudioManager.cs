using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource runMusic;
    public Slider sliderMusic;
    
    public AudioSource startSound;
    public Slider sliderSound;
    void Start()
    {
        sliderMusic.value = runMusic.volume;
        sliderMusic.onValueChanged.AddListener(ChangeMusic);

        sliderSound.value = startSound.volume;
        sliderSound.onValueChanged.AddListener(ChangeStartSound);
    }

    public void ChangeMusic(float volume)
    {
        runMusic.volume = volume;
    }
    public void ChangeStartSound(float volume)
    {
        startSound.volume = volume;
    }
}
