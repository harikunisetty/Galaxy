using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPostionAi : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] float nextAttack=0.01f;
    [SerializeField] float timer =10;
    //[SerializeField] float speed = 20f;
    [SerializeField] Transform fireTrans;
    [SerializeField] GameObject Ammo;
    [SerializeField] Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            timer = nextAttack;
            Vector3 postion = transform.rotation * velocity;
            Instantiate(Ammo, transform.position + postion, transform.rotation);
        }
           // Fire();
           
    }
    /*void Fire()
    {
        GameObject Go = Instantiate(Ammo, fireTrans.position, Quaternion.identity, this.transform);
        Go.GetComponent<Rigidbody2D>().AddForce(this.transform.InverseTransformVector(Vector3.up) * 5f, ForceMode2D.Impulse);
        Debug.Log("Fire");

    }*/
}

