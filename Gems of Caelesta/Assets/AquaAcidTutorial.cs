using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquaAcidTutorial : MonoBehaviour
{
    public GameObject aat, ob;
    public bool b;
    public Rigidbody2D rrr;

    void Start()
    {
        aat.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Guide"))
        {
            b = true;
            ob.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(b == true)
        {
            aat.SetActive(true);
            rrr.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Active!");
        }

        if(aat != null)
        {
            if(Input.GetKeyUp(KeyCode.C))
            {
                b = false;
                aat.SetActive(false);
                rrr.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
