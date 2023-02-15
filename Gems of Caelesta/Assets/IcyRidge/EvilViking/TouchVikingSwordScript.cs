using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchVikingSwordScript : MonoBehaviour
{
    public HealthScript hs;
    public bool invincible;

    void Start()
    {
        hs = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator turnNormal()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible = false;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("VikingsSword") && invincible == false)
        {
            hs.hurt = true;
            invincible = true;
            StartCoroutine(turnNormal());
        }
    }
}
