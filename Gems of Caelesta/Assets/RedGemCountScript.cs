using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedGemCountScript : MonoBehaviour
{
    //Variables to use
    public static int redGemCount;
    TextMeshProUGUI rgc;
    //public static RedGemCountScript moment;

    //Methods
    void Start()
    {
        redGemCount = 0;
        rgc.text = redGemCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rgc.text = redGemCount.ToString();
    }
}
