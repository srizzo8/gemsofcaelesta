using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepSuperGems : MonoBehaviour
{
    public int ksg;
    // Update is called once per frame
    private void Update()
    {
        ksg = SuperGem2.superGemCount;
    }
}
