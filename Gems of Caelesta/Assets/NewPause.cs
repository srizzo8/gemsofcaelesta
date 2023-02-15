using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPause : MonoBehaviour
{
    public static bool yesPaused = false, yesOptions = false;
    public GameObject pauseScreen, optionsScreen, exitOption, audioSlider;
    public Rigidbody2D rb2d;
    public OptionsSounds os;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            PauseTheGame();
        }

        if(yesOptions == true)
        {
            OptionsPanel();
            pauseScreen.SetActive(false);
        }

        //audioSource.volume = soundEffectVolume;
    }
    void PauseTheGame()
    {
        pauseScreen.SetActive(true);
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yesPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeTheGame()
    {
        pauseScreen.SetActive(false);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        yesPaused = false;
        Time.timeScale = 1;
    }
    public void OptionsPanel()
    {
        optionsScreen.SetActive(true);
        os.s.transform.position = new Vector3(425f, 200f, 0f);
        pauseScreen.SetActive(false);
        exitOption.SetActive(true);
        yesOptions = true;
        yesPaused = false;
        Debug.Log("Options");
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        Time.timeScale = 0;
    }

    public void GetOutOfOptions()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        pauseScreen.SetActive(true);
        optionsScreen.SetActive(false);
        os.s.transform.position = new Vector3(9999f, 9999f, 0f);
        pauseScreen.SetActive(true);
        exitOption.SetActive(false);
        yesPaused = true;
        yesOptions = false;
        Time.timeScale = 0;
    }

    public void exitLevel()
    {
        SceneManager.LoadScene("Scene003");
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        Time.timeScale = 1;
    }
/*
    public void volumeOfSoundEffects(float volume)
    {
        soundEffectVolume = volume;
    }*/
}
