using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperGemScript : MonoBehaviour
{
    public GameObject sg;
    public AuroraControls auroraControls;
    public int sgshow1 = 0;
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Start engines");
    }

    void Update()
    {
        if(auroraControls.countRedGems > 77 && sgshow1 == 0)
        {
            Debug.Log("Supergem must show");
            GetComponent<SpriteRenderer>().enabled = true;
            sgshow1 = 1;
            sg.transform.position = new Vector3(460.01f, -20.1f, 0f);
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