using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuturisticSignScriptControls : MonoBehaviour
{
    public GameObject controlsPanel;
    public Rigidbody2D rb2d;

    void Start()
    {
        controlsPanel.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("DrAurora"))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("SignOfTheFuture");
                Time.timeScale = 0;
                controlsPanel.SetActive(true);
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    void Update()
    {
        if(controlsPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("09876");
                controlsPanel.SetActive(false);
                Time.timeScale = 1;
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
