using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelmanScript : MonoBehaviour
{
    public Animator an2;
    public GameObject barrelman;
    public int w;
    
    void Start()
    {
        an2 = GetComponent<Animator>();
        w = 1;
    }

    void ThrowPlease()
    {
        switch(w)
        {
            case 0:
                StartCoroutine(dontThrowBarrel());
                break;
            case 1:
                StartCoroutine(throwBarrel());
                break;
        }
    }

    IEnumerator throwBarrel()
    {
        an2.SetBool("yesThrow", true);
        yield return new WaitForSeconds(2.583f);
        StopAllCoroutines();
        w = 0;
        yield break;
    }

    IEnumerator dontThrowBarrel()
    {
        an2.SetBool("yesThrow", false);
        yield return new WaitForSeconds(3.875f);
        StopAllCoroutines();
        w = 1;
        yield break;
    }

    void Update()
    {
        if(barrelman.GetComponent<SpriteRenderer>().enabled == true && barrelman.GetComponent<Rigidbody2D>().simulated == true)
        {
            ThrowPlease();
        }
    }
}
