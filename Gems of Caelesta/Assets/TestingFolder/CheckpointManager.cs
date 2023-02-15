using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public GameObject c0, c1, c2;
    public int i;

    void Start()
    {
        i = 0;
    }

    void Update()
    {
        switch(i)
        {
            case 0:
                Debug.Log("C0");
                break;
            case 1:
                Debug.Log("C1");
                break;
            case 2:
                Debug.Log("C2");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D h1)
    {
        if(h1.gameObject.name == "Checkpoint0" && i != 1 && i != 2)
        {
            i = 0;
            c0.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(h1.gameObject.name == "Checkpoint1" && i == 0 && i != 2)
        {
            i = 1;
            c1.GetComponent<SpriteRenderer>().enabled = false;
            c0.SetActive(false);
        }
        if(h1.gameObject.name == "Checkpoint2" && i == 1 && i != 0)
        {
            i = 2;
            c2.GetComponent<SpriteRenderer>().enabled = false;
            c1.SetActive(false);
        }
        if(h1.gameObject.name == "Checkpoint2" && i == 0 && i != 1)
        {
            i = 2;
            c2.GetComponent<SpriteRenderer>().enabled = false;
            c0.SetActive(false);
            c1.SetActive(false);
        }
    }
}
