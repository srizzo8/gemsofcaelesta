using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippedRunningEnemyScript : MonoBehaviour
{
    public float distanceFromCharacter;
    public Animator ar2;
    public GameObject enemylater2;
    private Transform draurora3;
    Rigidbody2D rigidBody2;
    float xaxismoveenemy = 0f;
    float speed = 1.5f;

    void Start() 
    {
        ar2 = GetComponent<Animator>();
        draurora3 = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rigidBody2 = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if((Vector3.Distance(draurora3.position, enemylater2.transform.position) < 7.5f) && enemylater2.GetComponent<SpriteRenderer>().enabled == true && enemylater2.GetComponent<Rigidbody2D>().simulated == true)
        {
            ar2.Play("LarinianSoldierWalk");
            //Debug.Log("Can walk");
            enemylater2.transform.Translate(1 * Time.deltaTime * speed, 0,0);
        }
        else
        {
            ar2.Play("StillLarinianSoldier");
            //Debug.Log("Can't walk");
        }
    }
}