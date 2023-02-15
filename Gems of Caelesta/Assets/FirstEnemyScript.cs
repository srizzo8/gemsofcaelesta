using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemyScript : MonoBehaviour
{
    public AuroraAttackingScript attackingScriptBoolean;
    public GameObject enemyDefeatedPanel;
    public Rigidbody2D rb2d;

    void Start()
    {
        attackingScriptBoolean = GameObject.FindWithTag("DrAurora").GetComponent<AuroraAttackingScript>();
        enemyDefeatedPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(attackingScriptBoolean.GetComponent<AuroraAttackingScript>().bo2 == true) //Why is this showing when it's not supposed to 100820?
        {
            enemyDefeatedPanel.SetActive(true);
            //Debug.Log("Do I work? 3");
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            enemyDefeatedPanel.SetActive(false);
            //Debug.Log("You don't");
        }

        if(enemyDefeatedPanel != null)
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                attackingScriptBoolean.GetComponent<AuroraAttackingScript>().bo2 = false;
                enemyDefeatedPanel.SetActive(false);
                rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
