using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptAtEnemyRedGem : MonoBehaviour
{
    public GameObject enemy2, rg;
    public Vector3 originalLocation;

    void Start(){
        originalLocation = new Vector3(rg.transform.position.x, rg.transform.position.y, rg.transform.position.z);
    }

    void Update(){
        if(enemy2.GetComponent<SpriteRenderer>().enabled == false && enemy2.GetComponent<Rigidbody2D>().simulated == false){
            rg.transform.position = enemy2.transform.position;
            Debug.Log("should transport");
        }
        
        if(enemy2.GetComponent<SpriteRenderer>().enabled == true && enemy2.GetComponent<Rigidbody2D>().simulated == true){
            rg.transform.position = originalLocation;
        }
    }
}
