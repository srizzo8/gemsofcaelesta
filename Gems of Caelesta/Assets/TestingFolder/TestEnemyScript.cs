using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour
{
    public CheckpointManager cm;
    public GameOver goov2;
    public GameObject[] enemiesblue, enemiesgreen, enemiesyellow;
    public GameObject enemy;
    public bool enemyBlueOn1, enemyBlueOn2, enemyGreenOn2;
    private List<GameObject> enemyBlueOn1List = new List<GameObject>();
    private List<GameObject> enemyBlueOn2List = new List<GameObject>();
    private List<GameObject> enemyGreenOn2List = new List<GameObject>();

    void Start()
    {
        Debug.Log("enemiesblue size: " + enemiesblue.Length);
        Debug.Log("enemiesgreen size: " + enemiesgreen.Length);
        Debug.Log("enemiesyellow size: " + enemiesyellow.Length);
    }

    void Update()
    {
        Debug.Log("enemiesblue size: " + enemiesblue.Length);
        Debug.Log("enemiesgreen size: " + enemiesgreen.Length);
        Debug.Log("enemiesyellow size: " + enemiesyellow.Length);
        if(cm.i == 0 && goov2.enemyback1 == true)
        {
            goov2.enemyback1 = false;
            foreach(GameObject enemyBlue in enemiesblue)
            {
                if(enemyBlue.GetComponent<SpriteRenderer>().enabled == false && enemyBlue.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemyBlue.GetComponent<SpriteRenderer>().enabled = true;
                    enemyBlue.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy1 in enemiesgreen)
            {
                if(enemy1.GetComponent<SpriteRenderer>().enabled == false && enemy1.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy1.GetComponent<SpriteRenderer>().enabled = true;
                    enemy1.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy in enemiesyellow)
            {
                if(enemy.GetComponent<SpriteRenderer>().enabled == false && enemy.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy.GetComponent<SpriteRenderer>().enabled = true;
                    enemy.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }
        if(cm.i == 1 && goov2.enemyback1 == true)
        {
            goov2.enemyback1 = false;
            foreach(GameObject enemyBlue in enemiesblue)
            {
                if(enemyBlueOn1 == true && enemyBlue.GetComponent<SpriteRenderer>().enabled == false && enemyBlue.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemyBlue.GetComponent<SpriteRenderer>().enabled = true;
                    enemyBlue.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy1 in enemiesgreen)
            {
                if(enemy1.GetComponent<SpriteRenderer>().enabled == false && enemy1.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy1.GetComponent<SpriteRenderer>().enabled = true;
                    enemy1.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy in enemiesyellow)
            {
                if(enemy.GetComponent<SpriteRenderer>().enabled == false && enemy.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy.GetComponent<SpriteRenderer>().enabled = true;
                    enemy.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }
        if(cm.i == 2 && goov2.enemyback1 == true)
        {
            goov2.enemyback1 = false;
            foreach(GameObject enemyBlue in enemiesblue)
            {
                if(enemyBlueOn2 == true && enemyBlue.GetComponent<SpriteRenderer>().enabled == false && enemyBlue.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemyBlue.GetComponent<SpriteRenderer>().enabled = true;
                    enemyBlue.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy1 in enemiesgreen)
            {
                if(enemyGreenOn2 == true && enemy1.GetComponent<SpriteRenderer>().enabled == false && enemy1.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy1.GetComponent<SpriteRenderer>().enabled = true;
                    enemy1.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
            foreach(GameObject enemy in enemiesyellow)
            {
                if(enemy.GetComponent<SpriteRenderer>().enabled == false && enemy.GetComponent<Rigidbody2D>().simulated == false)
                {
                    enemy.GetComponent<SpriteRenderer>().enabled = true;
                    enemy.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }

        //If a blue enemy is still on cm.i = 1:
        foreach(GameObject enemyBlue in enemiesblue)
        {
            if(enemyBlue.GetComponent<SpriteRenderer>().enabled == true && enemyBlue.GetComponent<Rigidbody2D>().simulated == true && cm.i == 1)
            {
                enemyBlueOn1 = true;
                enemyBlueOn1List.Add(enemyBlue);
            }
        }

        //If a blue or green enemy is still on cm.i = 2:
        foreach(GameObject enemyBlue in enemiesblue)
        {
            if(enemyBlue.GetComponent<SpriteRenderer>().enabled == true && enemyBlue.GetComponent<Rigidbody2D>().simulated == true && cm.i == 2)
            {
                enemyBlueOn2 = true;
                enemyBlueOn2List.Add(enemyBlue);
            }
        }
        foreach(GameObject enemy1 in enemiesgreen)
        {
            if(enemy1.GetComponent<SpriteRenderer>().enabled == true && enemy1.GetComponent<Rigidbody2D>().simulated == true && cm.i == 2)
            {
                enemyGreenOn2 = true;
                enemyGreenOn2List.Add(enemy1);
            }
        }
    }
}
