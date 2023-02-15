using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountLivesScript : MonoBehaviour
{
    public static int livesCount;
    TextMeshProUGUI lc;
    void Start()
    {
        livesCount = 3;
        lc.text = livesCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        lc.text = livesCount.ToString();
    }
}
