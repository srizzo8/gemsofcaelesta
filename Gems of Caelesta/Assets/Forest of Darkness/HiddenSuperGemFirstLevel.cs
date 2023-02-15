using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSuperGemFirstLevel : MonoBehaviour
{
    public GameObject gameObject1;
    public AuroraControls auroraControls;
    [SerializeField] private float showMelvl1 = 0f;

    void Start()
    {   
        GetComponent<SpriteRenderer>().enabled = false;
        showMelvl1 = PlayerPrefs.GetFloat("hiddensupergemlevel1");
    }

    void Update()
    {
        if(showMelvl1 == 0f)
        {
            gameObject1.transform.position = new Vector3(360.5f, -48f, 0f);
            GetComponent<SpriteRenderer>().enabled = true;
            PlayerPrefs.SetFloat("hiddensupergemlevel1", showMelvl1);
        }

        if(showMelvl1 == 1f)
        {
            gameObject1.transform.position = new Vector3(360.5f, -88.3f, 0f);
            PlayerPrefs.SetFloat("hiddensupergemlevel1", showMelvl1);
        }
       // Debug.Log("ShowMe is " + showMe);
       Debug.Log("3This is showmelvl1: " + showMelvl1);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("DrAurora"))
        {
            showMelvl1 = 1f;
            SuperGem2.superGemCount += 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
            PlayerPrefs.SetFloat("hiddensupergemlevel1", showMelvl1);
            //Debug.Log("ShowMe is " + showMe);
        }
    }
}
