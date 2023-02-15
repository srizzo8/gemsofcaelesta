using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScriptLevel2 : MonoBehaviour
{
    public Image h1, h2, h3;
    public GameObject dra;
    public bool hurt = false, mh1 = false, mh2 = false, mh3 = false, clicked = false;
    //AudioSource bsource;

    public GameObject gameOverPanel;
    public GameObject gameOverButton;

    public ForTheSwordLevel2 swordScript;
    public Rigidbody2D rb2d;

    void Start()
    {
        h1.enabled = true;
        h2.enabled = true;
        h3.enabled = true;
        mh1 = false;
        mh2 = false;
        mh3 = false;
        gameOverPanel.SetActive(false);
        gameOverButton.SetActive(false);
        //swordScript = GameObject.FindWithTag("DrAurora").GetComponent<ForTheSword>();
        //swordScript.forSword = false;
    }
    
    void OnCollisionEnter2D(Collision2D co)
    {
        if(co.gameObject.CompareTag("LarinianSoldier") && swordScript.forSword == false || co.gameObject.CompareTag("LarinianSoldier2") && swordScript.forSword == false)
        {
            hurt = true;
            Debug.Log("Debug me!");
        }
        
        if(co.gameObject.CompareTag("LarinianSoldier") && swordScript.forSword == true || co.gameObject.CompareTag("LarinianSoldier2") && swordScript.forSword == true) //Why doesn't this work yet it really is true?
        {
            hurt = false;
            Debug.Log("Debugme2");
        }
    }

    public void TakeDamage()
    {
        //Dr. Aurora hit once
        if(hurt == true && mh1 == false && mh2 == false && mh3 == false)
        {
            h1.enabled = false;
            //Debug.Log("Do I work?");
            hurt = false;
            mh1 = true;
            //bsource.Play();
        }

        //Dr. Aurora hit twice
        if(hurt == true && mh1 == true && mh2 == false && mh3 == false)
        {
            h2.enabled = false;
            //Debug.Log("I work?");
            hurt = false;
            mh2 = true;
            //bsource.Play();
        }

        //Dr. Aurora hit thrice/dies
        if(hurt == true && mh1 == true && mh2 == true && mh3 == false)
        {
            h3.enabled = false;
            //Debug.Log("Congrats. You killed Dr. Aurora");
            hurt = false;
            mh3 = true;
            dra.SetActive(false);
            //bsource.Play();
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        //When Dr. Aurora dies
        if(mh3 == true)
        {
            gameOverPanel.SetActive(true);
            gameOverButton.SetActive(true);
            //Debug.Log("Game over");
        }
    }

    void Update() 
    {
        TakeDamage();
    }

    public void clickMe3() 
    {
        //Game over panel pops up and clicking out of it
        if(gameOverPanel != null && gameOverButton != null)
        {
            gameOverPanel.SetActive(false);
            gameOverButton.SetActive(false);
            clicked = true;
        }

        //After you click out of the game over panel
        if(clicked == true)
        {
            SceneManager.LoadScene("Scene002"); //Resurrecting Dr. Aurora in level 2
            Debug.Log("In level 2");
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
