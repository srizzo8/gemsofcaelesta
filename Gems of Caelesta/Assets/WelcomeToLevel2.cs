using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeToLevel2 : MonoBehaviour
{
    public GameObject welcomeToLevel2Panel;
    public Rigidbody2D r2;
    public bool yesOn;

    void Start()
    {
        yesOn = true;
        if(yesOn == true)
        {
            welcomeToLevel2Panel.SetActive(true);
            r2.constraints = RigidbodyConstraints2D.FreezeAll;
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(welcomeToLevel2Panel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                yesOn = false;
                welcomeToLevel2Panel.SetActive(false);
                r2.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
            }
        }
    }
}
