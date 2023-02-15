using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSuperGemScriptLevel4 : MonoBehaviour
{
    public GameObject gameObject;
    public AuroraControls auroraControls;
    [SerializeField] private float showMelvl4 = 0f;

    void Start()
    {   
        GetComponent<SpriteRenderer>().enabled = false;
        showMelvl4 = PlayerPrefs.GetFloat("hiddensupergemlevel4");
    }

    void Update()
    {
        if(showMelvl4 == 0f)
        {
            gameObject.transform.position = new Vector3(159.6f, -11.1f, 0f);
            GetComponent<SpriteRenderer>().enabled = true;
            PlayerPrefs.SetFloat("hiddensupergemlevel4", showMelvl4);
        }

        if(showMelvl4 == 1f)
        {
            //gameObject.SetActive(false);
            PlayerPrefs.SetFloat("hiddensupergemlevel4", showMelvl4);
        }
       // Debug.Log("ShowMe is " + showMe);
       Debug.Log("3This is showmelvl4: " + showMelvl4);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("DrAurora"))
        {
            Debug.Log("Mario");
            showMelvl4 = 1f;
            SuperGem2.superGemCount += 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
            PlayerPrefs.SetFloat("hiddensupergemlevel4", showMelvl4);
            //Debug.Log("ShowMe is " + showMe);
        }
    }
}