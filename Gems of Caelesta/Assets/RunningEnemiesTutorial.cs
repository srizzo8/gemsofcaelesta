using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningEnemiesTutorial : MonoBehaviour
{
    public GameObject g, rescreen;
    public bool b2;
    public Rigidbody2D rigidbody2D;
    
    void Start()
    {
        rescreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("Guide2"))
        {
            b2 = true;
            g.SetActive(false);
        }
    }

    void Update()
    {
        if(b2 == true)
        {
            rescreen.SetActive(true);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(rescreen != null)
        {
            if(Input.GetKeyUp(KeyCode.C))
            {
                b2 = false;
                rescreen.SetActive(false);
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
