using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsSounds : MonoBehaviour
{
    public AudioSource aus;
    [SerializeField] public float soundEffectVolume;
    [SerializeField] public Slider s;

    void Awake() 
    {
        soundEffectVolume = PlayerPrefs.GetFloat("v1", soundEffectVolume); 
        s.transform.position = new Vector3(9999f, 9999f, 0f);
    }

    void Start() 
    {
        soundEffectVolume = PlayerPrefs.GetFloat("v1", soundEffectVolume);  
        aus.volume = soundEffectVolume;
        s.value = soundEffectVolume;  
        Debug.Log("Soundeffectvolume: " + soundEffectVolume);
    }

    public void volumeOfSoundEffects(float volume)
    {
        soundEffectVolume = volume;
    }

    void Update()
    {
        aus.volume = soundEffectVolume;
        PlayerPrefs.SetFloat("v1", soundEffectVolume);
        PlayerPrefs.Save();
    }
}
