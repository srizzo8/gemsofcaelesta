using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatEnemyScript : MonoBehaviour
{
    bool defeatTheEnemy;
    public GameObject enemy1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("LarinianSoldier"))
        {
            defeatTheEnemy = true;
            //Debug.Log("ah really?");
        }
        
        if(collider.gameObject.CompareTag("LarinianSoldier2"))
        {
            defeatTheEnemy = true;
            //Debug.Log("ah really?");
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(defeatTheEnemy == true)
            {
                enemy1.SetActive(false);
                Debug.Log("Killed me!");
                //rg.SetActive(true);
            }
        }
    }
}
