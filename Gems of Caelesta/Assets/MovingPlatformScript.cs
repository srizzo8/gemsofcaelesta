using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Vector3 startPoint, endPoint;
    public float speedOfPlatform = 0.2f;

    void Update() 
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speedOfPlatform, 1.0f));    
    }
}
