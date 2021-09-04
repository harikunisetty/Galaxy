using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAmmo : MonoBehaviour
{
    public float Speed = 5f;
    public float lifeTime = 5f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Speed, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
        }
          
    }
}
