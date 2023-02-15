using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallScript : MonoBehaviour
{
    public HealthScript ths2;
    public Rigidbody2D rb2dp2;

    void Start() 
    {
        ths2 = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    void OnCollisionEnter2D(Collision2D clsi2d)
    {
        if(clsi2d.gameObject.CompareTag("Pitfall"))
        {
            ths2.GetComponent<HealthScript>().hurt = true;
            ths2.GetComponent<HealthScript>().mh1 = true;
            ths2.GetComponent<HealthScript>().mh2 = true;
            ths2.GetComponent<HealthScript>().mh3 = true;
            ths2.h1.enabled = false;
            ths2.h2.enabled = false;
            ths2.h3.enabled = false;
            rb2dp2.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
