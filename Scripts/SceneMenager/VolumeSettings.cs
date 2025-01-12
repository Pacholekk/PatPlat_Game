using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    public void SetMusicVolume()
    {
        float volume = slider.value;
        audioMixer.SetFloat("music",Mathf.Log10(volume)*20);
    }
}
