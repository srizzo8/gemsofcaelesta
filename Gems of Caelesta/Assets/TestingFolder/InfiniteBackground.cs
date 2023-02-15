using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private Transform changingCamera;
    private Vector3 lastLocationOfCamera;
    private Vector3 moving;

    void Start()
    {
        changingCamera = Camera.main.transform;
        lastLocationOfCamera = changingCamera.position;
    }

    void LateUpdate() //called after all update functions have been called
    {
        moving = changingCamera.position - lastLocationOfCamera;
        transform.position += moving;
        lastLocationOfCamera = changingCamera.position; 
    }
}
