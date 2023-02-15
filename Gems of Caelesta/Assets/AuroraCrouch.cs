using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraCrouch : MonoBehaviour
{
    public Animator a4;
    Rigidbody2D rigbod2D;
    public bool yesCrouch, yesMove;

    void Start() 
    {
        a4 = GetComponent<Animator>();
        rigbod2D = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)) //For Dr. Aurora to crouch in the game
        {
            //Debug.Log("You crouched!");
            a4.Play("AuroraNewCrouch");
            a4.SetBool("yesCrouch", true);
            //a4.enabled = true;
            yesCrouch = true;
        }

        if(yesCrouch && Input.GetKeyDown(KeyCode.RightArrow) || yesCrouch && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Should not be crouching");
            yesCrouch = false;
            a4.SetBool("yesCrouch", false);
            a4.Play("AuroraNothing2");
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)) //Dr. Aurora when you don't press the down arrow.
        {
            a4.SetBool("yesCrouch", false);
            a4.Play("AuroraNothing2");
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            yesMove = true;
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            yesMove = false;
        }

        if(yesMove == true && yesCrouch == true)
        {
            a4.SetBool("yesCrouch", false);
            a4.Play("AuroraNothing2");
        }
    }
}
