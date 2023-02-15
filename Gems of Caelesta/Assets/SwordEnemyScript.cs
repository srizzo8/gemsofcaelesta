using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyScript : MonoBehaviour
{
    public Animator an2;
    public int s;

    void Start()
    {
        an2 = GetComponent<Animator>();
        s = 1;
    }

    IEnumerator useSword()
    {
        an2.Play("swordenemy");
        yield return new WaitForSeconds(1.583f);
        StopAllCoroutines();
        s = 0;
        yield break;
    }

    IEnumerator dontUseSword()
    {
        an2.Play("stillswordenemy");
        yield return new WaitForSeconds(3.166f);
        StopAllCoroutines();
        s = 1;
        yield break;
    }

    void swordUsing()
    {
        switch(s)
        {
            case 0:
                StartCoroutine(dontUseSword());
                break;
            case 1:
                StartCoroutine(useSword());
                break;
        }
    }

    void FixedUpdate()
    {
        swordUsing();
    }
}