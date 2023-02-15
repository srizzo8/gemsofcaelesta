using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auroraReactionToSpikes : MonoBehaviour
{
    public HealthScript healthy;
    public AudioSource aa;
    public AudioClip clip;

    IEnumerator auroraRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        healthy.invincible = true;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white; 
        healthy.invincible = false;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("CavernSpike") && healthy.invincible == false)
        {
            healthy.hurt = true;
            aa.clip = clip;
            aa.Play();
            StartCoroutine(auroraRed());
        }
    }
}
