using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstRedGemScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "FirstRedGem")
        {
            //Debug.Log("You collected the game's first red gem!");
            RedGemCountScript.redGemCount += 1;
            c.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
