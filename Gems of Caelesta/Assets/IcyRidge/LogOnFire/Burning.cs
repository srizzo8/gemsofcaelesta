using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : MonoBehaviour
{
    public HealthScript healthScript;
    public AudioSource audioSource;
    public AudioClip ouch2;
    public bool invincible2;

    void Start()
    {
        healthScript = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator ouch()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        invincible2 = true;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible2 = false;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Burning") && invincible2 == false)
        {
            healthScript.hurt = true;
            audioSource.clip = ouch2;
            audioSource.Play();
            StartCoroutine(ouch());
        }
    }
}
