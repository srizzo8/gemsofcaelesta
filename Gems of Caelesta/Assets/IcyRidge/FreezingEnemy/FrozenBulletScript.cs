using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenBulletScript : MonoBehaviour
{
    public HealthScript hs;
    public AudioSource bulletAudio;
    public AudioClip ouch;
    public bool invincible;
    public Rigidbody2D rb2d;

    void Start()
    {
        hs = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator TurnBlueToRed()
    {
        GetComponent<SpriteRenderer>().color = Color.cyan;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2.5f);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Debug.Log("Coroutine running");
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible = false;
    }

    void OnCollisionEnter2D(Collision2D frozenb)
    {
        if(frozenb.gameObject.CompareTag("FrozenBullet") && invincible == false)
        {
            //hs.hurt = true;
            bulletAudio.clip = ouch;
            bulletAudio.Play();
            invincible = true;
            Debug.Log("That hurt");
            StartCoroutine(TurnBlueToRed());
        }
    }
}
