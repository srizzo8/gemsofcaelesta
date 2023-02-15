using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupergemScriptLevel2 : MonoBehaviour
{
    public GameObject sg;
    public AuroraControls auroraControls;
    public int sgshowlvl2_1 = 0;
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Start engines");
    }

    void Update()
    {
        if(auroraControls.countRedGems > 82 && sgshowlvl2_1 == 0)
        {
            Debug.Log("Supergem must show");
            GetComponent<SpriteRenderer>().enabled = true;
            sgshowlvl2_1 = 1;
            sg.transform.position = new Vector3(437.45f, 1.6f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D s)
    {
        if(s.gameObject.tag == "SuperGem")
        {
            SuperGem2.superGemCount += 1;
            s.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
