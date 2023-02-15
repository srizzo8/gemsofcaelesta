using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCrystalScript : MonoBehaviour
{
    public Animator anim;
    public GameObject crystal;
    public int stages;
    public bool run, shine, hit;

    void Start(){
        stages = 1;
        run = true;
        hit = false;
    }

    IEnumerator crystalDoesNothing(){
        anim.SetBool("becomeLighter", false);
        anim.SetBool("shining", false);
        anim.SetBool("becomeDarker", false);
        anim.SetBool("backToDim", false);
        anim.Play("CrystalDoingNothing_052321");
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        stages = 2;
    }

    IEnumerator crystalBrightens(){
        anim.SetBool("becomeLighter", true);
        yield return new WaitForSeconds(0.3f);
        StopAllCoroutines();
        stages = 3;
    }

    IEnumerator crystalShines(){
        anim.SetBool("becomeLighter", false);
        anim.SetBool("shining", true);
        shine = true;
        yield return new WaitForSeconds(5f);
        StopAllCoroutines();
        shine = false;
        stages = 4;
    }

    IEnumerator crystalDarkens(){
        anim.SetBool("becomeLighter", false);
        anim.SetBool("shining", false);
        anim.SetBool("becomeDarker", true);
        yield return new WaitForSeconds(0.3f);
        StopAllCoroutines();
        stages = 5;
    }

    IEnumerator dimCrystal(){
        anim.SetBool("backToDim", true);
        anim.SetBool("becomeLighter", false);
        anim.SetBool("shining", false);
        anim.SetBool("becomeDarker", false);
        yield return new WaitForSeconds(0.0000001f);
        StopAllCoroutines();
        stages = 1;
        anim.SetBool("backToDim", false);
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c.gameObject.CompareTag("DrAurora") && shine == true){
            Debug.Log("Shining crystal");
            hit = true;
        }
    }

    void Update()
    {
        do
        {
            switch(stages)
            {
                case 1:
                    StartCoroutine(crystalDoesNothing());
                    break;
                case 2:
                    StartCoroutine(crystalBrightens());
                    break;
                case 3:
                    StartCoroutine(crystalShines());
                    break;
                case 4: 
                    StartCoroutine(crystalDarkens());
                    break;
                case 5:
                    StartCoroutine(dimCrystal());
                    break;
            }
        }
        while(run != true);
    }
}
