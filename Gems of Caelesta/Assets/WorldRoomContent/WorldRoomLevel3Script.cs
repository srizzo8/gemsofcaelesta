using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldRoomLevel3Script : MonoBehaviour
{
    public GameObject level03panel, unlockLevel3Panel;
    public bool lp3, unlockPlease, operate3;
    public Rigidbody2D rb2dd3;
    public GameObject worldp3;
    [SerializeField] private string lvlname3;
    public AuroraControls auroraControls;
    public PadScript pad;

    void Start()
    {
        level03panel.SetActive(false);
        unlockLevel3Panel.SetActive(false);
    }

    IEnumerator WaitingUnlocked()
    {
        operate3 = true;
        yield return new WaitForSeconds(pad.clip.length);
        if(operate3 == true)
        {
            lp3 = true;
        }
    }

    IEnumerator WaitingLocked()
    {
        operate3 = true;
        yield return new WaitForSeconds(pad.clip.length);
        if(operate3 == true)
        {
            unlockPlease = true;
        }
    }

    void OnCollisionEnter2D(Collision2D aaaa3)
    {
        if(aaaa3.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems > 1 && pad.s == true)
        {
            StartCoroutine(WaitingUnlocked());
        }
        if(aaaa3.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems < 2 && pad.s == true)
        {
            StartCoroutine(WaitingLocked());
        }
    }

    void OnCollisionExit2D(Collision2D aaaa3_2)
    {
        if(aaaa3_2.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems > 1 && pad.s == false)
        {
            operate3 = false;
        }
        if(aaaa3_2.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems < 2 && pad.s == false)
        {
            operate3 = false;
        }
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene(lvlname3);
    }

    void Update()
    {
        if(unlockPlease == true)
        {
            unlockLevel3Panel.SetActive(true);
            Time.timeScale = 0;
            rb2dd3.constraints = RigidbodyConstraints2D.FreezeAll;

            if(unlockLevel3Panel != null)
            {
                if(Input.GetKeyDown(KeyCode.C))
                {
                    Time.timeScale = 1;
                    rb2dd3.constraints = RigidbodyConstraints2D.FreezeRotation;
                    unlockLevel3Panel.SetActive(false);
                    unlockPlease = false;
                }
            }
        }
        
        if(lp3 == true)
        {
            Time.timeScale = 0;
            rb2dd3.constraints = RigidbodyConstraints2D.FreezeAll;
            level03panel.SetActive(true);

        if(level03panel != null)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log(lvlname3);
                GoToLevel3();
                level03panel.SetActive(false);
                Time.timeScale = 1;
                lp3 = false;
            }
            
            if(Input.GetKeyDown(KeyCode.N))
            {
                rb2dd3.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
                level03panel.SetActive(false);
                lp3 = false;
            }
        }
        }
    }
}

