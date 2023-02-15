using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrAuroraActivatingBorealia : MonoBehaviour
{
    public BorealiaMovementScript bms;
    
    void OnTriggerEnter2D(Collider2D c){
        if(c.gameObject.CompareTag("Borealia"))
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Talk to me");
            }
        }
    }
}
