using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrapScript : MonoBehaviour
{
    public GameObject icicle, draurora2;
    public Rigidbody2D rb2d;
    public HealthScript hs;
    public AudioSource audioSource;
    public AudioClip hurtzdonut;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D c5)
    {
        if(c5.gameObject.CompareTag("DrAurora"))
        {
            Debug.Log("Should I be working?");
            rb2d.isKinematic = false;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    IEnumerator turningRed()
    {
        draurora2.GetComponent<SpriteRenderer>().color = Color.red;
        hs.invincible = true;
        yield return new WaitForSeconds(2.5f);
        draurora2.GetComponent<SpriteRenderer>().color = Color.white;
        hs.invincible = false;
    }

    void OnCollisionEnter2D(Collision2D collidedWithMe)
    {
        if(collidedWithMe.gameObject.CompareTag("DrAurora") && hs.invincible == false)
        {
            Debug.Log("RIP Dr. Aurora");
            hs.hurt = true;
            audioSource.clip = hurtzdonut;
            audioSource.Play();
            StartCoroutine(turningRed());
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }

        if(collidedWithMe.gameObject.CompareTag("Grass"))
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }

        if(collidedWithMe.gameObject.CompareTag("Ice"))
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
