using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    public int count = 1;
    public bool s1;
    public GameObject door;

    void Start()
    {
        door.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("BigDoor"))
        {
            s1 = true;
        }
        else
        {
            s1 = false;
        }
    }

    void Update()
    {
        if(s1 == true)
        {
            switch(count)
            {
                case 1:
                    Debug.Log("Hit me two more times");
                    s1 = false;
                    count++;
                    break;
                case 2:
                    Debug.Log("Hit me again");
                    s1 = false;
                    count++;
                    break;
                case 3:
                    Debug.Log("You got it");
                    s1 = false;
                    door.SetActive(false);
                    break;
            }
        }
    }
}
