using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float distanceFromCharacter;
    public Animator ar;
    public GameObject enemylater;
    private Transform draurora;
    Rigidbody2D rigidBody2;
    float xaxismoveenemy = 0f;
    float speed = 1.5f;

    void Start() 
    {
        ar = GetComponent<Animator>();
        draurora = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rigidBody2 = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if((Vector3.Distance(draurora.position, enemylater.transform.position) < 7.5f) && enemylater.GetComponent<SpriteRenderer>().enabled == true && enemylater.GetComponent<Rigidbody2D>().simulated == true)
        {
            ar.Play("LarinianSoldierWalk");
            //Debug.Log("Can walk");
            enemylater.transform.Translate(-1 * Time.deltaTime * speed, 0,0);
        }
        else
        {
            ar.Play("StillLarinianSoldier");
            //Debug.Log("Can't walk");
        }
    }
}
