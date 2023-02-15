using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKeysDoor : MonoBehaviour
{
    public KeyScript k;
    public GameObject door;
    public bool d;
    void Start()
    {
        door.SetActive(true);
        d = false;
    }

    void Update()
    {
        if(d == true && k.t == true){
            door.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("DrAurora"))
        {
            d = true;
        }
    }

    void OnCollisionExit2D(Collision2D c2)
    {
        if(c2.gameObject.CompareTag("DrAurora"))
        {
            d = false;
        }
    }
}
