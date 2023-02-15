using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathScript : MonoBehaviour
{
    public AudioSource a;
    public AudioClip hurt2;

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("FireBreath"))
        {
            Debug.Log("Working123");
            a.clip = hurt2;
            a.Play();
        }
    }
}
