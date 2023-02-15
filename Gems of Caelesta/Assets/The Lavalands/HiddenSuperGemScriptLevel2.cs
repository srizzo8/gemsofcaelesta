using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenSuperGemScriptLevel2 : MonoBehaviour
{
    public GameObject gameObject;
    public AuroraControls auroraControls;
    [SerializeField] private float showMelvl2 = 0f;

    void Start()
    {   
        GetComponent<SpriteRenderer>().enabled = false;
        showMelvl2 = PlayerPrefs.GetFloat("hiddensupergemlevel2");
    }

    void Update()
    {
        if(showMelvl2 == 0f)
        {
            gameObject.transform.position = new Vector3(199f, 23.2f, 0f);
            GetComponent<SpriteRenderer>().enabled = true;
            PlayerPrefs.SetFloat("hiddensupergemlevel2", showMelvl2);
        }

        if(showMelvl2 == 1f)
        {
            //gameObject.SetActive(false);
            PlayerPrefs.SetFloat("hiddensupergemlevel2", showMelvl2);
        }
       // Debug.Log("ShowMe is " + showMe);
       Debug.Log("3This is showmelvl2: " + showMelvl2);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("DrAurora"))
        {
            Debug.Log("Mario");
            showMelvl2 = 1f;
            SuperGem2.superGemCount += 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
            PlayerPrefs.SetFloat("hiddensupergemlevel2", showMelvl2);
            //Debug.Log("ShowMe is " + showMe);
        }
    }
}
