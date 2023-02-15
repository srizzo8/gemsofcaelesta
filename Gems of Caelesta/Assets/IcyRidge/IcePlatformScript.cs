using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatformScript : MonoBehaviour
{
    public bool touchIce, enterIce;
    public Rigidbody2D rigidbody2d;
    public AuroraControls ac;
    float stop;

    void Start()
    {
        enterIce = false;
    }

    IEnumerator IceGoRight()
    {
        rigidbody2d.velocity = new Vector2(5.5f, rigidbody2d.velocity.y);
        rigidbody2d.AddForce(new Vector2(15f, 0f));
        yield return new WaitForSeconds(2.5f);
        rigidbody2d.AddForce(new Vector2(-15f, 0f));
        StopAllCoroutines();
        yield break;
    }

    IEnumerator IceGoLeft()
    {
        rigidbody2d.velocity = new Vector2(-5.5f, rigidbody2d.velocity.y);
        rigidbody2d.AddForce(new Vector2(-15f, 0f));
        yield return new WaitForSeconds(2.5f);
        rigidbody2d.AddForce(new Vector2(-15f, 0f));
        StopAllCoroutines();
        yield break;
    }

    void Update()
    {
        if(touchIce)
        {
            ac.aurorasSpeed = 1.5f;
            if(Time.timeScale == 1)
            {
                if(Input.GetKeyUp(KeyCode.RightArrow))
                {
                    StartCoroutine(IceGoRight());
                }
                if(Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    StartCoroutine(IceGoLeft());
                }

            }
        }
        else if(!touchIce)
        {
            ac.aurorasSpeed = 2f;
            Debug.Log("Not touching ice");
        }

        Debug.Log("Aurora's speed: " + ac.aurorasSpeed);
    }

    void OnCollisionEnter2D(Collision2D iceman)
    {
        if(iceman.gameObject.CompareTag("Ice"))
        {
            touchIce = true;
            enterIce = true;
            Debug.Log("Slippery");
        }
    }

    void OnTriggerEnter2D(Collider2D iceman1)
    {
        if(iceman1.gameObject.CompareTag("Ice"))
        {
            Debug.Log("Aurora on ice");
            if(enterIce == true)
            {
                touchIce = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D iceman2)
    {
        if(iceman2.gameObject.CompareTag("Ice"))
        {
            touchIce = true;
        }
    }

    void OnTriggerStay2D(Collider2D iceman25)
    {
        if(iceman25.gameObject.CompareTag("Ice"))
        {
            if(enterIce == true)
            {
                touchIce = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D iceman3)
    {
        if(iceman3.gameObject.CompareTag("Ice"))
        {
            touchIce = false;
        }
    }

    void OnTriggerExit2D(Collider2D iceman4)
    {
        if(iceman4.gameObject.CompareTag("Ice"))
        {
            touchIce = false;
            enterIce = false;
        }
    }
}
