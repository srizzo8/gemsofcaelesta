using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingEnemyScript : MonoBehaviour
{
    public float distanceFromAurora;
    public Animator anfes;
    public GameObject enemy;
    private Transform draurora3;
    public Rigidbody2D rigidbody2d;
    public int a;
    public AudioSource a1;
    public AudioClip clip2;
    public bool soundIsPlaying;

    void Start() 
    {
        anfes = GetComponent<Animator>();
        draurora3 = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        a = 1;
        soundIsPlaying = false;
    }

    void attacking()
    {
        switch(a)
        {
            case 0:
                soundIsPlaying = false;
                StartCoroutine(idle());
                break;
            case 1:
                StartCoroutine(attack());
                if(!soundIsPlaying)
                {
                    StartCoroutine(soundDelay());
                    soundIsPlaying = true;
                }
                break;
        }
    }

    IEnumerator soundDelay()
    {
        yield return new WaitForSeconds(0.3f);
        soundIsPlaying = true;
        a1.PlayOneShot(clip2);
        yield return new WaitForSeconds(1.367f);
        StopAllCoroutines();
        yield break;
    }

    IEnumerator attack()
    {
        anfes.Play("freezingenemyattack");
        yield return new WaitForSeconds(1.667f);
        StopAllCoroutines();
        a = 0;
        yield break;
    }

    IEnumerator idle()
    {
        anfes.Play("freezingenemyidle");
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        a = 1;
        yield break;
    }

    void Update()
    {
        if((Vector3.Distance(draurora3.position, enemy.transform.position) < 10f) && enemy.GetComponent<SpriteRenderer>().enabled == true && enemy.GetComponent<Rigidbody2D>().simulated == true)
        {
            attacking();
        }
        else
        {
            a = 0;
            anfes.Play("freezingenemyidle");
        }
    }
}