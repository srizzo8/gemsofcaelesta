using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaAcidScript : MonoBehaviour
{
    public HealthScript ths;
    public AudioSource dsource;
    public AudioClip aqua;
    public Rigidbody2D rb2d;

    void Start() 
    {
        ths = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
        dsource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D cd)
    {
        if(cd.gameObject.CompareTag("AquaAcid"))
        {
            ths.GetComponent<HealthScript>().hurt = true;
            ths.GetComponent<HealthScript>().mh1 = true;
            ths.GetComponent<HealthScript>().mh2 = true;
            ths.GetComponent<HealthScript>().mh3 = true;
            ths.h1.enabled = false;
            ths.h2.enabled = false;
            ths.h3.enabled = false;
            dsource.clip = aqua;
            dsource.Play();
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
