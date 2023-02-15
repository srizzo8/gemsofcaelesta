using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackFrostsBullet : MonoBehaviour
{
    public FreezingEnemyScript freezingEnemyScript;
    public bool hit;

    void Start()
    {
        hit = false;
    }

    void OnCollisionEnter2D(Collision2D jf2)
    {
        if(jf2.gameObject.CompareTag("DrAurora"))
        {
            freezingEnemyScript.a = 0;
            Debug.Log("Freezing here");
            hit = true;
        }
    }
}
