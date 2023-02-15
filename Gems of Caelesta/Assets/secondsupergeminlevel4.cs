using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secondsupergeminlevel4 : MonoBehaviour
{
    public GameObject sg4;
    public AuroraControls auroraControls;
    public float sgFour = 0f;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        sgFour = PlayerPrefs.GetFloat("level4supergem2");
    }

    void Update()
    {
        if(auroraControls.countRedGems > 93 && sgFour == 0f)
        {
            Debug.Log("Supergem must show");
            GetComponent<SpriteRenderer>().enabled = true;
            sgFour = 1f;
            sg4.transform.position = new Vector3(504f, -3f, 0f);
            PlayerPrefs.SetFloat("level4supergem2", sgFour);
        }
    }

    void OnTriggerEnter2D(Collider2D slevel4)
    {
        if(slevel4.gameObject.tag == "SuperGem")
        {
            SuperGem2.superGemCount += 1;
            slevel4.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
