using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenBarrelExplodes : MonoBehaviour
{
    public HealthScript hsc1;
    public AudioSource audioSource;
    public AudioClip painSound, ac;
    public bool invincibility;
    void Start()
    {
        hsc1 = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator ChangeBackToNormal()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincibility = false;
    }

    void OnCollisionEnter2D(Collision2D hn)
    {
        if(hn.gameObject.CompareTag("Explosion") && invincibility == false)
        {
            hsc1.hurt = true;
            invincibility = true;
            audioSource.clip = painSound;
            audioSource.clip = ac;
            audioSource.Play();
            audioSource.Play();
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ChangeBackToNormal());
        }
    }
}
