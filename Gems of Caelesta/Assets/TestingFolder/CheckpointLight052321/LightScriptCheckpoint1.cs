using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScriptCheckpoint1 : MonoBehaviour
{
    public Animator an;
    public GameObject light1;
    public bool turningOn;
    
    IEnumerator turnedOn(){
        yield return new WaitForSeconds(0.250f);
        an.SetBool("PermanentOn", true);
        an.SetBool("TurnOn", false);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Checkpoint1")
        {
            turningOn = true;
            Debug.Log("On!");
        }
    }
    void Update()
    {
        if(turningOn == true){
            an.SetBool("TurnOn", true);
            StartCoroutine(turnedOn());
        }
        if(turningOn == false){
            an.SetBool("TurnOff", false);
        }
    }
}
