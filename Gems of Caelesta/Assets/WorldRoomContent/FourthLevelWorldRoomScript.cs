using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FourthLevelWorldRoomScript : MonoBehaviour
{
    public GameObject level04panel, unlockLevel4Panel;
    public bool lp4, unlockPlease, operate4;
    public Rigidbody2D rb2dd4;
    public GameObject worldp4;
    [SerializeField] private string lvlname4;
    public AuroraControls auroraControls;
    public PadScript pad4;

    void Start()
    {
        level04panel.SetActive(false);
        unlockLevel4Panel.SetActive(false);
    }

    IEnumerator WaitingUnlocked4()
    {
        operate4 = true;
        yield return new WaitForSeconds(pad4.clip.length);
        if(operate4 == true)
        {
            lp4 = true;
        }
    }

    IEnumerator WaitingLocked4()
    {
        operate4 = true;
        yield return new WaitForSeconds(pad4.clip.length);
        if(operate4 == true)
        {
            unlockPlease = true;
        }
    }

    void OnCollisionEnter2D(Collision2D aaaa4)
    {
        if(aaaa4.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems > 3 && pad4.s == true)
        {
            StartCoroutine(WaitingUnlocked4());
        }
        if(aaaa4.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems < 4 && pad4.s == true)
        {
            StartCoroutine(WaitingLocked4());
        }
    }

    void OnCollisionExit2D(Collision2D aaaa4_2)
    {
        if(aaaa4_2.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems > 3 && pad4.s == false)
        {
            operate4 = false;
        }
        if(aaaa4_2.gameObject.CompareTag("DrAurora") && auroraControls.countSuperGems < 4 && pad4.s == false)
        {
            operate4 = false;
        }
    }

    public void GoToLevel4()
    {
        SceneManager.LoadScene(lvlname4);
    }

    void Update()
    {
        if(unlockPlease == true)
        {
            unlockLevel4Panel.SetActive(true);
            Time.timeScale = 0;
            rb2dd4.constraints = RigidbodyConstraints2D.FreezeAll;

            if(unlockLevel4Panel != null)
            {
                if(Input.GetKeyDown(KeyCode.C))
                {
                    Time.timeScale = 1;
                    rb2dd4.constraints = RigidbodyConstraints2D.FreezeRotation;
                    unlockLevel4Panel.SetActive(false);
                    unlockPlease = false;
                }
            }
        }
        
        if(lp4 == true)
        {
            Time.timeScale = 0;
            rb2dd4.constraints = RigidbodyConstraints2D.FreezeAll;
            level04panel.SetActive(true);

        if(level04panel != null)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log(lvlname4);
                GoToLevel4();
                level04panel.SetActive(false);
                Time.timeScale = 1;
                lp4 = false;
            }
            
            if(Input.GetKeyDown(KeyCode.N))
            {
                rb2dd4.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
                level04panel.SetActive(false);
                lp4 = false;
            }
        }
        }
    }
}