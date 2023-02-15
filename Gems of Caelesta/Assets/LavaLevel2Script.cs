using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaLevel2Script : MonoBehaviour
{
    public HealthScript healthScriptLevel2;
    public AudioSource dsource2;
    public AudioClip lava;
    public Rigidbody2D rb2d;

    void Start()
    {
        healthScriptLevel2 = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
        dsource2 = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Lava"))
        {
            healthScriptLevel2.GetComponent<HealthScript>().hurt = true;
            healthScriptLevel2.GetComponent<HealthScript>().mh1 = true;
            healthScriptLevel2.GetComponent<HealthScript>().mh2 = true;
            healthScriptLevel2.GetComponent<HealthScript>().mh3 = true;
            healthScriptLevel2.h1.enabled = false;
            healthScriptLevel2.h2.enabled = false;
            healthScriptLevel2.h3.enabled = false;
            dsource2.clip = lava;
            dsource2.Play();
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
 