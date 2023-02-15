using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionToFreezingBullet : MonoBehaviour
{
    public JackFrostsBullet j;
    public Rigidbody2D rb2d;

    IEnumerator Freeze()
    {  
        GetComponent<SpriteRenderer>().color = Color.cyan;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(2.5f);
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<SpriteRenderer>().color = Color.white;
        j.hit = false;
    }

    void Update()
    {
        if(j.hit == true)
        {
            StartCoroutine(Freeze());
        }
    }
}
