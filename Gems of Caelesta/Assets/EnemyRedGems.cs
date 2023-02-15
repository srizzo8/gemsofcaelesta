using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedGems : MonoBehaviour
{
    public GameObject erg;
    public AuroraAttackingScript attackingScript;
    void Start()
    {
        erg.SetActive(false);
        //attackingScript = GetComponent<AuroraAttackingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackingScript.rgYes == true)
        {
            Debug.Log("1252");
            erg.SetActive(true);
        }
    }
}
