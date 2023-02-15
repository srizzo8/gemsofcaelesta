using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSwordItselfScript : MonoBehaviour
{
    public ForTheSword forTheSword;
    public HealthScript healthScript;
    public GameObject enemy;
    public AudioSource asource4;
    public AudioClip hurt3;

    IEnumerator ChangeBack2()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void OnCollisionEnter2D(Collision2D cccc)
    {
        if(cccc.gameObject.CompareTag("TheSwordItself") && forTheSword.forSword == false)
        {
            healthScript.hurt = true;
            Debug.Log("Try again");
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ChangeBack2());
            asource4.clip = hurt3;
            asource4.Play();
        }
        if(cccc.gameObject.CompareTag("TheSwordItself") && forTheSword.forSword == true)
        {
            healthScript.hurt = false;
            enemy.SetActive(false);
            Debug.Log("You defeated the enemy!");
        }
    }
}
