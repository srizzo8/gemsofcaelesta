using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionScript012921 : MonoBehaviour
{
    public Animator animator;

    public int i = 0;

    void Start()
    {
        i = 0;
    }

    IEnumerator shining()
    {
        animator.Play("TVShining");
        yield return new WaitForSeconds(2.166f);
        i = 1;
        StopAllCoroutines();
        yield break;
    }

    IEnumerator turningRed()
    {
        animator.Play("TVTurningRed");
        yield return new WaitForSeconds(4.017f);
        i = 0;
        StopAllCoroutines();
        yield break;
    }

    void televisionPlay()
    {
        switch(i)
        {
            case 0:
                StartCoroutine(shining());
                break;
            case 1:
                StartCoroutine(turningRed());
                break;
        }
    }

    void Update(){
        televisionPlay();
    }
}
