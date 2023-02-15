using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedGemScriptNumber2 : MonoBehaviour
{
    public GameObject[] red, blue, green, yellow;
    public GameObject redd;
    public AuroraControls ac;
    public AudioSource rgSource;
    public AudioClip redGemSound;
    public GameOver goov;
    public CheckpointManager cm;
    public bool blueOn1, blueOn2, greenOn2;
    private List<GameObject> blueOn1List = new List<GameObject>();
    private List<GameObject> blueOn2List = new List<GameObject>();
    private List<GameObject> greenOn2List = new List<GameObject>();

    void Start(){
        Debug.Log("blues count: " + blue.Length);
        Debug.Log("greens count: " + green.Length);
        Debug.Log("yellows count: " + yellow.Length);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.CompareTag("DrAurora") && redd.GetComponent<SpriteRenderer>().enabled == true)
        {
            goov.resurrect = false;
            Debug.Log("The Samantha Fox red gem");
            ac.countRedGems += 1;
            rgSource.clip = redGemSound;
            rgSource.Play();
            redd.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if(ac.countRedGems < 0)
        {
            ac.countRedGems = 0;
        }
        if(goov.resurrect == true && cm.i == 0 && redd.GetComponent<SpriteRenderer>().enabled == false)
        {
            goov.resurrect = false;
            foreach(GameObject blues in blue)
            {
                if(blues.GetComponent<SpriteRenderer>().enabled == false)
                {
                    blues.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            foreach(GameObject greens in green)
            {
                if(greens.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("1 is the right number");
                    greens.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            foreach(GameObject yellows in yellow)
            {
                if(yellows.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("3 is the right number");
                    yellows.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
        }
        if(goov.resurrect == true && cm.i == 1 && redd.GetComponent<SpriteRenderer>().enabled == false)
        {
            goov.resurrect = false;
            Debug.Log("blueOn1 is: " + blueOn1);
            foreach(GameObject blues in blueOn1List)
            {
                if(blueOn1 == true && blues.GetComponent<SpriteRenderer>().enabled == false)
                {
                    blues.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            Debug.Log("greens count: " + green.Length);
            foreach(GameObject greens in green)
            {
                if(greens.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("1 is the right number");
                    greens.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            foreach(GameObject yellows in yellow)
            {
                if(yellows.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("3 is the right number");
                    yellows.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
        }
        if(goov.resurrect == true && cm.i == 2 && redd.GetComponent<SpriteRenderer>().enabled == false)//works
        {
            Debug.Log("amarillo count: " + yellow.Length);
            goov.resurrect = false;
            foreach(GameObject blues in blueOn2List)
            {
                if(blueOn2 == true && blues.GetComponent<SpriteRenderer>().enabled == false)
                {
                    blues.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            foreach(GameObject greens in greenOn2List)
            {
                if(greenOn2 == true && greens.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("ThegreensDisappear");
                    greens.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
            foreach(GameObject yellows in yellow)
            {
                if(yellows.GetComponent<SpriteRenderer>().enabled == false)
                {
                    Debug.Log("3 is the right number");
                    yellows.GetComponent<SpriteRenderer>().enabled = true;
                    ac.countRedGems -= 1;
                }
            }
        }

        //If a blue is still on cm.i=1
        foreach(GameObject blues in blue)
        {
            if(blues.GetComponent<SpriteRenderer>().enabled == true && cm.i == 1)
            {
                blueOn1 = true;
                blueOn1List.Add(blues);
                //Debug.Log("blueOn1List size: " + blueOn1List.Count);
            }
        }

        //If a blue is still on cm.i=2 and a green is still on cm.i=2
        foreach(GameObject blues in blue)
        {
            if(blues.GetComponent<SpriteRenderer>().enabled == true && cm.i == 2)
            {
                blueOn2 = true;
                blueOn2List.Add(blues);
                //Debug.Log("blueOn2List size: " + blueOn2List.Count);
            }
        }
        foreach(GameObject greens in green)
        {
            if(greens.GetComponent<SpriteRenderer>().enabled == true && cm.i == 2)
            {
                greenOn2 = true;
                greenOn2List.Add(greens);
                //Debug.Log("greenOn2List size: " + greenOn2List.Count);
            }
        }
    }
}
