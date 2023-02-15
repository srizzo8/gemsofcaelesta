using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondSupergemInLevel3 : MonoBehaviour
{
    public GameObject sg3;
    public AuroraControls auroraControls;
    public float sgThree = 0f;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        sgThree = PlayerPrefs.GetFloat("level3supergem");
    }

    void Update()
    {
        if(auroraControls.countRedGems > 78 && sgThree == 0f)
        {
            Debug.Log("Supergem must show");
            GetComponent<SpriteRenderer>().enabled = true;
            sgThree = 1f;
            sg3.transform.position = new Vector3(473.8f, -1.7f, 0f);
            PlayerPrefs.SetFloat("level3supergem", sgThree);
        }
    }

    void OnTriggerEnter2D(Collider2D slevel3)
    {
        if(slevel3.gameObject.tag == "SuperGem")
        {
            SuperGem2.superGemCount += 1;
            slevel3.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}

