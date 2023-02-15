using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSprite : MonoBehaviour
{
    public HealthScript healthScript;
    public Image h1_2, h2_2, h3_2;
    public GameObject heart;

    void OnTriggerEnter2D(Collider2D c3)
    {
        if(healthScript.mh1 == true && h1_2.enabled == false)
        {
            h1_2.enabled = true;
            healthScript.mh1 = false;
            heart.SetActive(false);
        }

        if(healthScript.mh2 == true && h2_2.enabled == false)
        {
            h2_2.enabled = true;
            h1_2.enabled = false;
            healthScript.mh2 = false;
            healthScript.mh1 = true;
            heart.SetActive(false);
        }

        if(healthScript.mh1 == false && healthScript.mh2 == false && healthScript.mh3 == false && h1_2.enabled == true && h2_2.enabled == true && h3_2.enabled == true)
        {
            heart.SetActive(false);
        }
    }
}
