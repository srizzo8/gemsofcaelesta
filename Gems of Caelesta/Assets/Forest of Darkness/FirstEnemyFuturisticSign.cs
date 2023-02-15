using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyFuturisticSign : MonoBehaviour
{
    public GameObject firstEnemyPanel;
    public Rigidbody2D rigidbody2D;
    void Start()
    {
        firstEnemyPanel.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D c1)
    {
        if(c1.gameObject.CompareTag("DrAurora"))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("ReadMe");
                Time.timeScale = 0;
                firstEnemyPanel.SetActive(true);
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    void Update()
    {
        if(firstEnemyPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                firstEnemyPanel.SetActive(false);
                Time.timeScale = 1;
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
