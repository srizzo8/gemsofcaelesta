using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarpPadLevel3 : MonoBehaviour
{
    public Animator animator;
    public AuroraControls auroraControls;
    public bool touched, warping = false;

    [System.NonSerialized] public bool goToOtherLevel;

    public GameObject needRedGemsPanel, dr4, WarpingPad;

    public Rigidbody2D rigidbody2D;

    public AudioSource esource;
    public AudioClip warp;

    void Start()
    {
        animator = GetComponent<Animator>();
        auroraControls = GameObject.FindWithTag("DrAurora").GetComponent<AuroraControls>();
        needRedGemsPanel.SetActive(false);
        esource = GetComponent<AudioSource>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if(touched == true && auroraControls.countRedGems > 78)
        {
            animator.SetBool("yesDisappear", true);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            esource.clip = warp;
            esource.Play();
            Debug.Log("You completed the level!");
            touched = false;
            goToOtherLevel = true;
        }

        if(touched == true && auroraControls.countRedGems < 79)
        {
            Debug.Log("Get some more red gems!");
            needRedGemsPanel.SetActive(true);
            touched = false;
        }    

        if(needRedGemsPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                needRedGemsPanel.SetActive(false);
            }
        }
        
        if(goToOtherLevel == true)
        {
            Debug.Log("I should work");
            StartCoroutine(Going());
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("WarpPad"))
        {
            touched = true;
        }
        else
        {
            touched = false;
        }
    }

    IEnumerator Going()
    {
        yield return new WaitForSeconds(4.0f);
        //dr4.transform.position = new Vector2(-48.95f, -110.2f);
        SceneManager.LoadScene("Scene003");
        animator.SetBool("yesDisappear", false);
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        auroraControls.countRedGems = 0;
    }
}
