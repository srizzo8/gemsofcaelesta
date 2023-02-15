using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform aurora;
    public float cameraSize = 35.0f;
    
    void Awake() 
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraSize);
    }
    void FixedUpdate() 
    {
        transform.position = new Vector3(aurora.position.x, aurora.position.y, transform.position.z);
    }
}
