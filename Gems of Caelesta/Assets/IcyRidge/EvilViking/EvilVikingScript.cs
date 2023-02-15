using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilVikingScript : MonoBehaviour
{
    public float distanceFromAurora;
    public Animator an3;
    public GameObject viking;
    private Transform draurora4;
    Rigidbody2D rb2d;
    float xaxismoveviking = 0f;
    float vikingSpeed = 1.5f;
    public int k;

    void Start()
    {
        an3 = GetComponent<Animator>();
        draurora4 = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        k = 0;
    }

    IEnumerator vikingPreparation()
    {
        an3.Play("evilvikingprepare");
        yield return new WaitForSeconds(0.167f);
        StopAllCoroutines();
        k = 1;
        yield break;
    }

    IEnumerator vikingAttack()
    {
        an3.Play("evilvikingattack");
        yield return new WaitForSeconds(0.167f);
        StopAllCoroutines();
        yield break;
    }

    void Update()
    {
        if((Vector3.Distance(draurora4.position, viking.transform.position) < 5.5f) && viking.GetComponent<SpriteRenderer>().enabled == true && viking.GetComponent<Rigidbody2D>().simulated == true)
        {
            viking.transform.Translate(-1 * Time.deltaTime * vikingSpeed, 0,0);
            switch(k)
            {
                case 0:
                    StartCoroutine(vikingPreparation());
                    break;
                case 1:
                    StartCoroutine(vikingAttack());
                    break;
            }
        }
        else
        {
            an3.Play("evilvikingidle");
            k = 0;
        }
    }
}
