using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTheSword : MonoBehaviour
{
    public HealthScript healthScript;
    public Collider2D sword;
    public Collider2D enemy;

    public bool forSword = false;

    void Start()
    {
        healthScript = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
        sword = GameObject.FindGameObjectWithTag("EnemyHitSprite").GetComponent<PolygonCollider2D>();
        enemy = GameObject.FindGameObjectWithTag("LarinianSoldier").GetComponent<PolygonCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D co2d)
    {
        if(co2d.gameObject.CompareTag("LarinianSoldier") || co2d.gameObject.CompareTag("LarinianSoldier2"))
        {
            Debug.Log("Use your weapon for no pain");
            forSword = true;
            //healthScript.GetComponent<HealthScript>().hurt = false;
        }
    }

    void OnCollisionExit2D(Collision2D c2d)
    {
        if(c2d.gameObject.CompareTag("LarinianSoldier") || c2d.gameObject.CompareTag("LarinianSoldier2"))
        {
            forSword = false;
            //Debug.Log("Not using sword");
        }
    }

    void Update()
    {
    }
}
