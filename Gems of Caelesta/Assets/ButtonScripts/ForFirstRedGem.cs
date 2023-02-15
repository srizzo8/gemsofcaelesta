using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForFirstRedGem : MonoBehaviour
{
    public GameObject secondPanel, frg;
    public Rigidbody2D rb2d;
    public int i = 0;
    public static bool redGemDetected = false;
    public GameOver goo;
    
    void Start()
    {
        //Turns the panel talking about the first red gem and its button off.
        secondPanel.SetActive(false);
    }

    void FirstRedGem()
    {
        switch(i)
        {
            case 0:
                redGemDetected = true;
                i++;
                break;
            case 1:
                redGemDetected = false;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //If you touch the first red gem in the game
        if(c.gameObject.CompareTag("FirstRedGem"))
        {
            FirstRedGem();
        }
        else
            Debug.Log("Red Gem Not Detected!");
    }

    void Update() 
    {
        if(redGemDetected == true && frg.GetComponent<SpriteRenderer>().enabled == false)
        {
            secondPanel.SetActive(true);
            //Debug.Log("You got it");
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            Time.timeScale = 0;
        }

        if(secondPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                redGemDetected = false;
                secondPanel.SetActive(false);
                //Debug.Log("click me!");
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
            }
        }

        if(goo.resurrect == true){
            i = 0;
        }
    }
}