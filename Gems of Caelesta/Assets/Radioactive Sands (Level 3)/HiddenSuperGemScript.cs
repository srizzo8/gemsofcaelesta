using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSuperGemScript : MonoBehaviour
{
    public GameObject gameObject;
    public AuroraControls auroraControls;
    public float showMe = 0f;

    void Start()
    {   
        GetComponent<SpriteRenderer>().enabled = false;
        showMe = PlayerPrefs.GetFloat("hiddensupergem");
    }

    void Update()
    {
        if(showMe == 0f)
        {
            gameObject.transform.position = new Vector3(303.8f, -26.12f, 0f);
            GetComponent<SpriteRenderer>().enabled = true;
            PlayerPrefs.SetFloat("hiddensupergem", showMe);
        }

        if(showMe == 1f)
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetFloat("hiddensupergem", showMe);
        }
       // Debug.Log("ShowMe is " + showMe);
       Debug.Log("I am showme: " + showMe);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "SuperGem")
        {
            showMe = 1f;
            SuperGem2.superGemCount += 1;
            collider.gameObject.SetActive(false);
            Destroy(gameObject);
            PlayerPrefs.SetFloat("hiddensupergem", showMe);
            //Debug.Log("ShowMe is " + showMe);
        }
    }
}
