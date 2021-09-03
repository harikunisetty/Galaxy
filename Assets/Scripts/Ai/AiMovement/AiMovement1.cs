using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement1 : MonoBehaviour
{
    public float Speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Speed, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
