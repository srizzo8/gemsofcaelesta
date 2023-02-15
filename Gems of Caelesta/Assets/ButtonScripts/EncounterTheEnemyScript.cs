using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterTheEnemyScript : MonoBehaviour
{
    public GameObject thirdPanel;
    public Rigidbody2D rb2d;

    [System.NonSerialized] public static bool seeEnemy = false;
    void Start()
    {
        thirdPanel.SetActive(false);
    }

    //When you touch a text sprite that is camouflaged to the grass, you will see a panel
    //that talks about what you should do when encountering an enemy.
    //If you step on the sprite, it will disappear.
    void OnTriggerEnter2D(Collider2D c3)
    {
        if(c3.gameObject.CompareTag("FET2"))
        {
            c3.gameObject.SetActive(false);
            seeEnemy = true;
            //Debug.Log("Enemy detected!");
        }
    }
    void Update()
    {
        //After you step on the sprite camouflaged to the grass,
        //a panel that talks about what to do when encountering enemies will appear.
        if(seeEnemy == true)
        {
            thirdPanel.SetActive(true);
            //Debug.Log("Take cover!");
            //Debug.Log(thirdButton.activeSelf); //see if it is set active.
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if(thirdPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                //Debug.Log("345");
                thirdPanel.SetActive(false);
                seeEnemy = false;
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
