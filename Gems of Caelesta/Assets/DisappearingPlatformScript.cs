using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformScript : MonoBehaviour
{
    public GameObject gameObject;

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(Resurrect());
    }

    IEnumerator Resurrect()
    {
        yield return new WaitForSeconds(6f);
        GetComponent<Rigidbody2D>().simulated = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("DrAurora"))
        {
            StartCoroutine(Disappear());
        }
    }
}
