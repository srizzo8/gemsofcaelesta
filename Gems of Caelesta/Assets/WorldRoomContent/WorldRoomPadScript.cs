using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldRoomPadScript : MonoBehaviour
{
    public GameObject level01panel;
    public bool lp1, operate;
    public Rigidbody2D rb2dd;
    public GameObject worldp1;
    [SerializeField] private string lvlname;
    public PadScript p;
    // Start is called before the first frame update
    void Start()
    {
        level01panel.SetActive(false);
    }

    IEnumerator Waiting()
    {
        operate = true;
        yield return new WaitForSeconds(p.clip.length);
        if(operate == true)
        {
            lp1 = true;
        }
    }

    void OnCollisionEnter2D(Collision2D aaaa)
    {
        if(aaaa.gameObject.CompareTag("DrAurora") && p.s == true)
        {
            Debug.Log("Big Yes");
            StartCoroutine(Waiting());
        }
    }

    void OnCollisionExit2D(Collision2D aaab)
    {
        if(aaab.gameObject.CompareTag("DrAurora") && p.s == false)
        {
            Debug.Log("Big No");
            operate = false;
        }
    }

    void Update()
    {
        if(lp1 == true)
        {
            Time.timeScale = 0;
            rb2dd.constraints = RigidbodyConstraints2D.FreezeAll;
            level01panel.SetActive(true);

        if(level01panel != null)
        {
            if(Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log(lvlname);
                SceneManager.LoadScene(lvlname);
                level01panel.SetActive(false);
                Time.timeScale = 1;
                lp1 = false;
            }

            if(Input.GetKeyDown(KeyCode.N))
            {
                rb2dd.constraints = RigidbodyConstraints2D.FreezeRotation;
                Time.timeScale = 1;
                level01panel.SetActive(false);
                lp1 = false;
            }
        }
        }
    }
}
