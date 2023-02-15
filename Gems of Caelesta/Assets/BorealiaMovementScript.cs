using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorealiaMovementScript : MonoBehaviour
{
    public Animator boreal;
    public GameObject p1, p2, p3, p4;
    public bool b;
    public int i;

    void Start(){
        i = UnityEngine.Random.Range(1, 5);
        Debug.Log("i = " + i);
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        b = true;
    }

    IEnumerator Action2()
    {
        Debug.Log("Work");
        boreal.Play("BorealiaNothing");
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        b = false;
        yield break;
    }
    IEnumerator NoAction()
    {
        boreal.Play("idleBorealia");
        yield return new WaitForSeconds(0.167f);
        StopAllCoroutines();
        b = true;
        yield break;
    }

    void anyMovement()
    {
        switch(b){
            case true:
                StartCoroutine(Action2());
                break;
            case false:
                StartCoroutine(NoAction());
                break;
        }
    }

    void saySomething(){
        Debug.Log("Say something");
        if(i == 1)
        {
            p1.SetActive(true);
            Time.timeScale = 0;
        }
        if(i == 2)
        {
            p2.SetActive(true);
            Time.timeScale = 0;
        }
        if(i == 3)
        {
            p3.SetActive(true);
            Time.timeScale = 0;
        }
        if(i == 4)
        {
            p4.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("DrAurora"))
        {
            Debug.Log("32253");
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Talk to me");
                saySomething();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        anyMovement();
        if(p1 != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Please shut down");
                p1.SetActive(false);
                i = UnityEngine.Random.Range(1, 5);
                Time.timeScale = 1;
            }
        }
        if(p2 != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Please shut down");
                p2.SetActive(false);
                i = UnityEngine.Random.Range(1, 5);
                Time.timeScale = 1;
            }
        }
        if(p3 != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Please shut down");
                p3.SetActive(false);
                i = UnityEngine.Random.Range(1, 5);
                Time.timeScale = 1;
            }
        }
        if(p4 != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Please shut down");
                p4.SetActive(false);
                i = UnityEngine.Random.Range(1, 5);
                Time.timeScale = 1;
            }
        }
    }
}
