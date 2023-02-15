using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaterEnemiesScript : MonoBehaviour
{
    public GameObject laterEnemy;
    
    void OnCollisionEnter2D(Collision2D c2)
    {
        if(c2.gameObject.CompareTag("EnemyHitSprite"))
        {
            //Debug.Log("Hit me");
            laterEnemy.SetActive(false);
        }
    }
}
