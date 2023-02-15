using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource redGemCollectAudio;
    public AudioSource jumpAudio;

    void Start()
    {
        redGemCollectAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
