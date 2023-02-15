using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel, gameOverButton, toastPanel, toastButton;
    public HealthScript hhss;
    public AuroraControls auroraControls;
    public Rigidbody2D r3;
    public string sceneName;
    public bool resurrect = false, enemyback1 = false;
    public int lives;

    void Start(){
        lives = 3;
    }

    public void clickMe3() 
    {
        //Game over panel pops up and clicking out of it
        if(gameOverPanel != null && gameOverButton != null)
        {
            hhss.mh3 = false;
            hhss.mh2 = false;
            hhss.mh1 = false;
            hhss.hurt = false;
            hhss.h1.enabled = true;
            hhss.h2.enabled = true;
            hhss.h3.enabled = true;
            gameOverPanel.SetActive(false);
            gameOverButton.SetActive(false);
            hhss.clicked = true;
            Time.timeScale = 1;
            if(auroraControls.c == true)
            {
                switch(lives)
                {
                    case 3:
                        resurrect = true;
                        enemyback1 = true;
                        Debug.Log("I'm respawning somewhere else");
                        r3.transform.position = new Vector2(auroraControls.respawn.x, auroraControls.respawn.y+5);
                        r3.constraints = RigidbodyConstraints2D.FreezeRotation;
                        auroraControls.c = false;
                        auroraControls.GetComponent<SpriteRenderer>().color = Color.white;
                        lives = 2;
                        auroraControls.countLives2 = 2;
                        break;
                    case 2:
                        resurrect = true;
                        enemyback1 = true;
                        Debug.Log("I'm respawning somewhere else");
                        r3.transform.position = new Vector2(auroraControls.respawn.x, auroraControls.respawn.y+5);
                        r3.constraints = RigidbodyConstraints2D.FreezeRotation;
                        auroraControls.c = false;
                        auroraControls.GetComponent<SpriteRenderer>().color = Color.white;
                        lives = 1;
                        auroraControls.countLives2 = 1;
                        break;
                }
            }
            else
            {
                SceneManager.LoadScene(sceneName);
                Debug.Log("False");
            }
        }
    }

    public void defeated()
    {
        if(toastPanel != null && toastButton != null)
        {
            hhss.mh3 = false;
            hhss.mh2 = false;
            hhss.mh1 = false;
            hhss.hurt = false;
            hhss.h1.enabled = true;
            hhss.h2.enabled = true;
            hhss.h3.enabled = true;
            toastPanel.SetActive(false);
            toastButton.SetActive(false);
            hhss.clicked = true;
            Time.timeScale = 1;
            SceneManager.LoadScene("Scene003");
        }
    }
}
