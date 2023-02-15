using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformsTutorial : MonoBehaviour
{
    public GameObject dpt, ob2;
    public bool b3;
    public Rigidbody2D r2;

    void Start()
    {
        dpt.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D cc)
    {
        if(cc.gameObject.CompareTag("Guide3"))
        {
            b3 = true;
            ob2.SetActive(false);
        }
    }
    
    void Update()
    {
        if(b3 == true)
        {
            dpt.SetActive(true);
            r2.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(dpt != null)
        {
            if(Input.GetKeyUp(KeyCode.C))
            {
                b3 = false;
                dpt.SetActive(false);
                r2.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
