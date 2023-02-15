using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public Image h1, h2, h3;
    public GameObject dra;
    public bool hurt = false, mh1 = false, mh2 = false, mh3 = false, clicked = false;
    public bool invincible;
    //AudioSource bsource;

    public GameObject gameOverPanel;
    public GameObject gameOverButton;
    public GameObject toastPanel, toastButton;

    public ForTheSword swordScript;

    public AuroraControls auroraControls;

    public AudioSource rg2Source;
    public AudioClip hurtSound2;

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
        toastPanel.SetActive(false);
        toastButton.SetActive(false);
        //swordScript = GameObject.FindWithTag("DrAurora").GetComponent<ForTheSword>();
        //swordScript.forSword = false;
        //AuroraControls = GameObject.FindGameObjectWithTag("DrAurora").GetComponent<AuroraControls>();
    }
    
    IEnumerator turnRegular()
    {
        yield return new WaitForSeconds(2.5f);
        invincible = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    void OnCollisionEnter2D(Collision2D co)
    {
        if(co.gameObject.CompareTag("LarinianSoldier") && swordScript.forSword == false && invincible == false || co.gameObject.CompareTag("LarinianSoldier2") && swordScript.forSword == false && invincible == false)
        {
            hurt = true;
            invincible = true;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(turnRegular());
            Debug.Log("Debug me!");
            rg2Source.clip = hurtSound2;
            rg2Source.Play();
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
            //dra.SetActive(false);
            //bsource.Play();
            Time.timeScale = 0;
        }

        //When Dr. Aurora dies
        if(mh3 == true && auroraControls.countLives2 == 3 || mh3 == true && auroraControls.countLives2 == 2)
        {
            gameOverPanel.SetActive(true);
            gameOverButton.SetActive(true);
            //Debug.Log("Game over");
        }

        //If Dr. Aurora loses all his lives
        if(mh3 == true && auroraControls.countLives2 == 1)
        {
            toastPanel.SetActive(true);
            toastButton.SetActive(true);
        }
    }

    void Update() 
    {
        TakeDamage();
    }
}
