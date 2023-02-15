using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactionToCrystal : MonoBehaviour
{
    public HealthScript healthy;
    public AudioSource aa;
    public AudioClip clip;
    public TheCrystalScript TheCrystalScript;

    IEnumerator auroraRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        healthy.invincible = true;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white; 
        healthy.invincible = false;
    }

    void Update()
    {
        if(TheCrystalScript.hit == true && healthy.invincible == false)
        {
            TheCrystalScript.hit = false;
            healthy.hurt = true;
            aa.clip = clip;
            aa.Play();
            StartCoroutine(auroraRed());
        }
    }
}