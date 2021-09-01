using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float deathTime = 0.001f;
    private void Awake()
    {
        Destroy(this.gameObject, deathTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Touch Enemy");
        }
    }
}
