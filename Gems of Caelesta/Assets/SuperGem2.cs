using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuperGem2 : MonoBehaviour
{
    public static int superGemCount;
    TextMeshProUGUI sgc;

    void Start()
    {
        superGemCount = 0;
        sgc.text = superGemCount.ToString();
    }

    void Update()
    {
        sgc.text = superGemCount.ToString();
    }
}
