using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilacPlatformTutorial : MonoBehaviour
{
    public GameObject lpt, ob5;
    public bool b5;
    public Rigidbody2D r2d;

    void Start()
    {
        lpt.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D cccc)
    {
        if(cccc.gameObject.CompareTag("Guide5"))
        {
            b5 = true;
            ob5.SetActive(false);
        }
    }
    void Update()
    {
        if(b5 == true)
        {
            lpt.SetActive(true);
            r2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(lpt != null)
        {
            if(Input.GetKeyUp(KeyCode.C))
            {
                b5 = false;
                lpt.SetActive(false);
                r2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
