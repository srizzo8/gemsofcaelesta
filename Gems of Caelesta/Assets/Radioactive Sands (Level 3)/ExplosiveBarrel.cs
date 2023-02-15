using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject eb;
    public Animator animatingBarrel;

    void Start()
    {
        animatingBarrel = GetComponent<Animator>();
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        eb.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c2dbarrel)
    {
        if(c2dbarrel.gameObject.CompareTag("DrAurora"))
        {
            animatingBarrel.SetBool("be", true);
            animatingBarrel.SetTrigger("explodingbarrelanimation");
            StartCoroutine(Disappear());
            Debug.Log("Explode now");
        }
    }
}
