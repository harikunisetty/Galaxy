using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public Transform player;
    public float lifetime;
    void Start()
    {
       
    }
  void Update()
    {
        if (player == null)
        {
            GameObject Target = GameObject.Find("PlayerGo");
            if (Target != null)
            {
                player = Target.transform;
            }
        }
        if (player == null)
            return;
        Vector3 dir = player.position - transform.position; 
    }
}
