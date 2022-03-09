using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //Written by Edwin Aguirre/Tutorial
    
    [SerializeField]
    private AudioMixer musicMixer;
    [SerializeField]
    private AudioMixer uiClickMixer;
    [SerializeField]
    private AudioMixer uiHoverMixer;
    [SerializeField]
    private AudioMixer soundfxMixer;

    public void SetMusicLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSoundFXLevel(float sliderValue)
    {
        soundfxMixer.SetFloat("SoundFXVol", Mathf.Log10(sliderValue) * 20);
        uiClickMixer.SetFloat("ClickVol", Mathf.Log10(sliderValue) * 20);
        uiHoverMixer.SetFloat("HoverVol", Mathf.Log10(sliderValue) * 20);
    }
}
