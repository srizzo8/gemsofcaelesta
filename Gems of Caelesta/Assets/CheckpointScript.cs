using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject goo;
    public bool cp;
    public bool cp2 = false;
    public GameObject checkpointText;

    void Start() 
    {
        checkpointText.SetActive(false);
    }

    IEnumerator CheckpointAction()
    {
        checkpointText.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        checkpointText.SetActive(false);
        cp2 = true;
    }

    void OnTriggerEnter2D(Collider2D cc3)
    {
        if(cc3.gameObject.CompareTag("DrAurora"))
        {
            cp = true;
            Debug.Log("Checkpoint");
            if(cp2 == false)
            {
                Debug.Log("Checkpoint text shows up");
                StartCoroutine(CheckpointAction());
            }
            if(cp2 == true)
            {
                Debug.Log("Already a checkpoint");
            }
        }
    }
}
