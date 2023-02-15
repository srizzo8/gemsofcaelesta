using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelThrowingScript : MonoBehaviour
{
    public HealthScript healthScript;
    public AudioSource source1;
    public AudioClip hurts;
    public bool invincibleFromBarrel;
    void Start()
    {
        healthScript = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator radioactive()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        invincibleFromBarrel = true;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincibleFromBarrel = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Barrel2") && invincibleFromBarrel == false)
        {
            healthScript.hurt = true;
            source1.clip = hurts;
            source1.Play();
            StartCoroutine(radioactive());
        }
    }
}
