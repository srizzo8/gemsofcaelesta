using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
    public GameObject RedSign;
    public Rigidbody2D rb2d;
    bool on;

    void Start() 
    {
        on = true;
        if(on == true)
        {
            //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("3");
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if(RedSign != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                RedSign.SetActive(false);
                on = false;
                //rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
                Debug.Log("4");
            }
        }
    }
}
