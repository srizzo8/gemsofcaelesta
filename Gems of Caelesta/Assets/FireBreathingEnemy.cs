using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathingEnemy : MonoBehaviour
{
    public Animator an;
    public bool y;

    void Start()
    {
        an = GetComponent<Animator>();
        y = true;
    }

    IEnumerator hold()
    {
        an.SetBool("fire2", false);
        y = false;
        an.Play("stillfireenemy");
        yield return new WaitForSeconds(5);
        y = true;
    }

    void Update()
    {
        if(y == true)
        {
            Debug.Log("fire breath");
            an.SetBool("fire2", true);
            an.Play("enemybreathingfire");
            StartCoroutine(hold());
        }
    }
}
