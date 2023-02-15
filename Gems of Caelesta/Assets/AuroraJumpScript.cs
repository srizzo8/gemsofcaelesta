using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraJumpScript : MonoBehaviour
{
    public Animator aJump;
    Rigidbody2D rigidity;
    public AudioSource asource;
    public AudioClip jumpSound;

    bool onGround = true;
    void Start()
    {
        aJump = GetComponent<Animator>();
        rigidity = GetComponent<Rigidbody2D>();
        asource = GetComponent<AudioSource>();
    }

    //When you hit the ground
    void OnCollisionEnter2D(Collision2D col2d)
    {
        if(col2d.gameObject.tag == "Grass" || col2d.gameObject.tag == "DisappearingPlatform" || col2d.gameObject.tag == "MovingPlatform" || col2d.gameObject.tag == "Checkpoint" || col2d.gameObject.tag == "UpDownLilac" || col2d.gameObject.tag == "Barrel" || col2d.gameObject.tag == "Ice" || col2d.gameObject.tag == "Log" || col2d.gameObject.tag == "DeadlyCrystal")
        {
            onGround = true;
        }
    }

    void Update()
    {
        //When you press the space bar.
        if(Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            float jumpingF = 5f;
            rigidity.velocity = Vector2.up * jumpingF;
            aJump.Play("AuroraJumps");
            aJump.SetBool("yesJump", true);
            onGround = false;
            asource.clip = jumpSound;
            asource.Play();
        }

        //After you press the space bar/when you don't press the space bar
        if(Input.GetKeyUp(KeyCode.Space))
        {
            aJump.SetBool("yesJump", false);
            aJump.Play("AuroraNothing2");
        }
    }
}
