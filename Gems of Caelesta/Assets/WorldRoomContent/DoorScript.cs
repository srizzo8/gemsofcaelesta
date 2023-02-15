using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator animator;
    public GameObject da;
    public Transform drAurora, destination;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator DoorShuts()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("doorOpens", false);
        animator.Play("idledoor");
        da.GetComponent<Rigidbody2D>().simulated = true;
        da.GetComponent<SpriteRenderer>().enabled = true;
        drAurora.transform.position = destination.transform.position;
    }

    void OnTriggerStay2D(Collider2D d)
    {
        if(d.gameObject.CompareTag("DrAurora"))
        {
            Debug.Log("At the door");
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Open me");
                da.GetComponent<Rigidbody2D>().simulated = false;
                da.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DoorShuts());
                animator.SetBool("doorOpens", true);
                animator.Play("dooropen");
            }
        }
    }
}
