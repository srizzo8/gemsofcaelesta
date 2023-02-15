using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedGem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "RedGem" || c.gameObject.tag == "RedGem2")
        {
            RedGemCountScript.redGemCount += 1;
            c.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        //For my double gem collecting glitch when Dr. Aurora is jumping
        /*if(Input.GetKeyDown(KeyCode.Space) && c.gameObject.CompareTag("RedGem"))
        {
            RedGemCountScript.redGemCount += 1;
            c.gameObject.SetActive(false);
            Destroy(gameObject);
        }*/
    }
}
