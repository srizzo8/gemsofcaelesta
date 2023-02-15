using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    public int n;
    public bool up;
    public GameObject spike;
    void Start()
    {
        n = 0;
        up = false;
        spike.GetComponent<SpriteRenderer>().enabled = false;
        spike.GetComponent<PolygonCollider2D>().enabled = false;
    }

    IEnumerator nZero(){
        n = 0;
        up = false;
        yield return new WaitForSeconds(2.5f);
        StopAllCoroutines();
        n = 1;
        yield break;
    }

    IEnumerator nOne(){
        n = 1;
        up = true;
        yield return new WaitForSeconds(2.5f);
        StopAllCoroutines();
        n = 0;
        yield break;
    }

    void upDown(){
        switch(n)
        {
            case 0:
                StartCoroutine(nZero());
                break;
            case 1:
                StartCoroutine(nOne());
                break;
        }
    }

    void Update()
    {
        upDown();

        if(up == true){
            spike.GetComponent<SpriteRenderer>().enabled = true;
            spike.GetComponent<PolygonCollider2D>().enabled = true;
        }
        else{
            spike.GetComponent<SpriteRenderer>().enabled = false;
            spike.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
