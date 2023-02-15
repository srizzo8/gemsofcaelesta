using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttackingScriptForEnemies : MonoBehaviour
{
    public float distanceFromCharacter;
    public Animator ar2;
    public GameObject enemylater2;
    private Transform draurora2;
    public Rigidbody2D rigidBody2;
    public AudioSource asource;
    public AudioClip clip3;
    public bool playingSound;
    public int c;

    void Start() 
    {
        ar2 = GetComponent<Animator>();
        draurora2 = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rigidBody2 = GetComponent<Rigidbody2D>();
        playingSound = false;
        c = 1;
    }

    void theAttack()
    {
        switch(c)
        {
            case 0:
                playingSound = false;
                StartCoroutine(still());
                break;
            case 1:
                StartCoroutine(shoot());
                if(!playingSound)
                {
                    StartCoroutine(soundDelayLevel1());
                    playingSound = true;
                }
                break;
        }
    }

    IEnumerator soundDelayLevel1()
    {
        yield return new WaitForSeconds(0.3f);
        playingSound = true;
        asource.PlayOneShot(clip3);
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        yield break;
    }

    IEnumerator shoot()
    {
        ar2.Play("ShootActive1");
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        c = 0;
        yield break;
    }

    IEnumerator still()
    {
        ar2.Play("IdleShooting1");
        yield return new WaitForSeconds(2f);
        StopAllCoroutines();
        c = 1;
        yield break;
    }

    void Update() 
    {
        if((Vector3.Distance(draurora2.position, enemylater2.transform.position) < 5.5f) && enemylater2.GetComponent<SpriteRenderer>().enabled == true && enemylater2.GetComponent<Rigidbody2D>().simulated == true)
        {
            theAttack();
        }
        else
        {
            ar2.Play("IdleShooting1");
            c = 0;
        }
    }
}