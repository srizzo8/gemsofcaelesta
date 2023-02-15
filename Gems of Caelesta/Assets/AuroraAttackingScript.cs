using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraAttackingScript : MonoBehaviour
{
    //variables for Dr. Aurora's attacking animation
    public Animator a3;
    Rigidbody2D rb2d2;

    //Audio variables
    public AudioSource csource;
    public AudioClip swordUse;

    //Miscellaneous
    public GameObject ls, rg;

    public bool bo, bo2 = false, rgYes;

    void Start()
    {
        a3 = GetComponent<Animator>();
        rb2d2 = GetComponent<Rigidbody2D>();
        csource = GetComponent<AudioSource>();
        rgYes = false;
    }

    // Update is called once per frame
    void Update()
    {
        //You attack by pressing Z and this is what happens when you press Z
        if(Input.GetKeyDown(KeyCode.Z))
        {
            AuroraAttack();
        }

        //What happens after you press Z or do not press Z at all
        if(Input.GetKeyUp(KeyCode.Z))
        {
            //Debug.Log("Do not attack, player.");
            a3.SetBool("yesAttack", false);
            a3.Play("AuroraNothing2");
            bo = false;
        }
    }

    void AuroraAttack()
    {
        //Debug.Log("You pressed the attack key!");
        a3.Play("AuroraAttack");
        a3.SetBool("yesAttack", true);
        csource.clip = swordUse;
        csource.Play();
        bo = true;
    }

    void OnCollisionEnter2D(Collision2D cols2D)
    {
        if(bo == true)
        {
            if(cols2D.gameObject.CompareTag("LarinianSoldier"))
            {
                ls.GetComponent<SpriteRenderer>().enabled = false;
                ls.GetComponent<Rigidbody2D>().simulated = false;
                bo = false;
                bo2 = true;
                rgYes = true;
                //Instantiate(rg, cols2D.gameObject.transform.position, cols2D.gameObject.transform.rotation); //for red gem to appear where Larinian soldier is
                Debug.Log("Red gem should appear");
            }
            else
            {
                rgYes = false;
            }

            if(cols2D.gameObject.CompareTag("LarinianSoldier2"))
            {
                cols2D.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                cols2D.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                bo = false;
                bo2 = false;
                rgYes = true;
                //Instantiate(rg, cols2D.gameObject.transform.position, cols2D.gameObject.transform.rotation);
            }
            else
            {
                rgYes = false;
            }
        }
    }

            /*
            if(cols2D.gameObject.CompareTag("FirstRedGem") || (cols2D.gameObject.CompareTag("RedGem")))
            {
                frg.SetActive(true);
                rg2.SetActive(true);
                bo = false;
            }*/
}
