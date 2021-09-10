using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPostionAi : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] float nextAttack=0.01f;
    [SerializeField] float timer =10;
    [SerializeField] GameObject Ammo;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer<=0)
        {
            timer = nextAttack;
            Instantiate(Ammo, transform.position, transform.rotation);
        }           
    }
}

