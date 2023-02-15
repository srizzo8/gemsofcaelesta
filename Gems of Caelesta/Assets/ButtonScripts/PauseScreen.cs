using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pausePanel, pauseButton1, pauseButton2, optionsPanel, audioSlider, optionsButton;
    public Rigidbody2D rb2d;
    
    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton1.SetActive(false);
        pauseButton2.SetActive(false);
        optionsPanel.SetActive(false);
        audioSlider.SetActive(false);
        optionsButton.SetActive(false);
    }

    
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pausePanel.SetActive(true);
            pauseButton1.SetActive(true);
            pauseButton2.SetActive(true);
            optionsPanel.SetActive(false);
            audioSlider.SetActive(false);
            optionsButton.SetActive(false);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Paused");
        }
    }

    public void ClickPause()
    {
        if(pausePanel != null && pauseButton1 != null && pauseButton2 != null)
        {
            pausePanel.SetActive(false);
            pauseButton1.SetActive(false);
            pauseButton2.SetActive(false);
            optionsPanel.SetActive(false);
            audioSlider.SetActive(false);
            optionsButton.SetActive(false);
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            Time.timeScale = 1;
        }
    }

    public void Options() 
    {
        if(pausePanel != null && pauseButton1 != null && pauseButton2 != null)
        {
            pausePanel.SetActive(false);
            pauseButton1.SetActive(false);
            pauseButton2.SetActive(false);
            optionsPanel.SetActive(true);
            audioSlider.SetActive(true);
            optionsButton.SetActive(true);
        }
    }

    public void exitOptions()
    {
        if(optionsButton != null)
        {
            pausePanel.SetActive(true);
            pauseButton1.SetActive(true);
            pauseButton2.SetActive(true);
            optionsPanel.SetActive(false);
            audioSlider.SetActive(false);
            optionsButton.SetActive(false);
        }
    }
}
