using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxScript : MonoBehaviour
{
    public float scroll = -2.5f;
    public Vector2 startingPosition;
    public float updatedPosition;

    void Start(){
        startingPosition = transform.position;
    }

    void Update(){
        updatedPosition = Mathf.Repeat(Time.time * scroll, 20);
        transform.position = startingPosition + Vector2.right * updatedPosition;
    }
}
