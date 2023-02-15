using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public HealthScript healthScript;
    public AudioSource asource3;
    public AudioClip hurt2;
    public bool invincible;

    void Start()
    {
        healthScript = GameObject.FindWithTag("DrAurora").GetComponent<HealthScript>();
    }

    IEnumerator ChangeBack()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        invincible = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("BarrelFlare") && invincible == false)
        {
            healthScript.hurt = true;
            asource3.clip = hurt2;
            asource3.Play();
            GetComponent<SpriteRenderer>().color = Color.red;
            invincible = true;
            StartCoroutine(ChangeBack());
        }
    }
}
