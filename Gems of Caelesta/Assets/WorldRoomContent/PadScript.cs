using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    public SpriteRenderer green;
    public Sprite red, green2;
    public bool s, aftermath;
    public AudioSource audio;
    public AudioClip clip;

    void Start()
    {
        s = false;
        aftermath = false;
    }

    IEnumerator soundPlaying()
    {
        audio.clip = clip;
        audio.Play();
        yield return new WaitForSeconds(clip.length);
        StopAllCoroutines();
        yield break;
    }

    IEnumerator aftermathOfSomething()
    {
        aftermath = true;
        yield return new WaitForSeconds(3f);
        aftermath = false;
    }

    void turnRed()
    {
        green.sprite = red;
    }

    void OnCollisionEnter2D(Collision2D co)
    {
        if(co.gameObject.CompareTag("DrAurora"))
        {
            s = true;
            StartCoroutine(soundPlaying());
        }
    }

    void OnCollisionExit2D(Collision2D co2)
    {
        if(co2.gameObject.CompareTag("DrAurora"))
        {
            s = false;
            green.sprite = green2;
            StartCoroutine(aftermathOfSomething());
        }
    }
    
    void Update()
    {
        switch(s)
        {
            case true:
                turnRed();
                break;
            case false:
                if(audio.isPlaying && aftermath == true)
                {
                    audio.clip = clip;
                    audio.Stop();
                    Debug.Log("Aftermath");
                }
                break;
        }
    }
}