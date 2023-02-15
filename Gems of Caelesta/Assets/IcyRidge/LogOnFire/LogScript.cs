using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public Animator anim;
    public int b;

    void Start()
    {
        anim = GetComponent<Animator>();
        b = 1;
    }

    IEnumerator deadflames()
    {
        anim.Play("deadlog");
        yield return new WaitForSeconds(4f);
        StopAllCoroutines(); //use this in a coroutine to make coroutines not overlap
        b = 1;
        yield break;
    }

    IEnumerator activeFlames()
    {
        anim.Play("firelog");
        yield return new WaitForSeconds(2.250f);
        StopAllCoroutines();
        b = 0;
        yield break;
    }

    void WorkingFire()
    {
        switch(b)
        {
            case 0:
                StartCoroutine(deadflames());
                break;
            case 1:
                StartCoroutine(activeFlames());
                break;
        }
    }

    void FixedUpdate()
    {
        WorkingFire();
    }
}
