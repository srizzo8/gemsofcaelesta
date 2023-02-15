using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSwordsmanScript : MonoBehaviour
{
    public float distance;
    public Animator a;
    public GameObject swordsman3;
    private Transform doc;
    Rigidbody2D rb2d;
    public Rigidbody2D enemyrb2d;
    float xmoveenemy = 0f;
    float speed = 2f;

    void Start()
    {
        a = GetComponent<Animator>();
        doc = GameObject.FindWithTag("DrAurora").GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        enemyrb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(doc.position, swordsman3.transform.position) < 9f) && swordsman3.GetComponent<SpriteRenderer>().enabled == true && swordsman3.GetComponent<Rigidbody2D>().simulated == true)
        {
            a.SetBool("runningSwordYes", true);
            a.Play("LarinianSwordsmanAttack");
            swordsman3.transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            Debug.Log("Supposed to wield sword");
            enemyrb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            a.SetBool("runningSwordYes", false);
            a.Play("IdleSwordsMan011121");
        }
    }
}
