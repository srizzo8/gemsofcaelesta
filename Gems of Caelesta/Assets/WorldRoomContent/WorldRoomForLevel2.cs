using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldRoomForLevel2 : MonoBehaviour
{
    public GameObject level02panel;
    public bool lp2, operate2;
    public Rigidbody2D rb2dd2;
    public GameObject worldp2;
    [SerializeField] private string lvlname2;
    public PadScript p2;

    void Start()
    {
        level02panel.SetActive(false);
    }

    IEnumerator Waiting()
    {
        operate2 = true;
        yield return new WaitForSeconds(p2.clip.length);
        if(operate2 == true)
        {
            lp2 = true;
        }
    }

    void OnCollisionEnter2D(Collision2D aaaa2)
    {
        if(aaaa2.gameObject.CompareTag("DrAurora") && p2.s == true)
        {
            Debug.Log("Working3");
            StartCoroutine(Waiting());
        }
    }

    void OnCollisionExit2D(Collision2D aaab2)
    {
        if(aaab2.gameObject.CompareTag("DrAurora") && p2.s == false)
        {
            Debug.Log("Big No");
            operate2 = false;
        }
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(lvlname2);
    }

    void Update()
    {
        if(lp2 == true)
        {
            Time.timeScale = 0;
            rb2dd2.constraints = RigidbodyConstraints2D.FreezeAll;
            level02panel.SetActive(true);

        if(level02panel != null)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log(lvlname2);
                GoToLevel2();
                level02panel.SetActive(false);
                Time.timeScale = 1;
                lp2 = false;
            }
            
            if(Input.GetKeyDown(KeyCode.N))
            {
                rb2dd2.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
                level02panel.SetActive(false);
                lp2 = false;
            }
        }
        }
    }
}
