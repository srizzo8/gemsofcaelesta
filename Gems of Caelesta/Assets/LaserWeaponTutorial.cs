using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeaponTutorial : MonoBehaviour
{
    public GameObject lwt, ob4;
    public bool b4;
    public Rigidbody2D b2;

    void Start()
    {
        lwt.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Guide4"))
        {
            b4 = true;
            ob4.SetActive(false);
        }
    }

    void Update()
    {
        if(b4 == true)
        {
            lwt.SetActive(true);
            b2.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(lwt != null)
        {
            if(Input.GetKeyUp(KeyCode.C))
            {
                b4 = false;
                lwt.SetActive(false);
                b2.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
