using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] float attackIntervals = 0.5f;
    [SerializeField] float nextAttack;
    [SerializeField] float timer = 0;
    [SerializeField] float speed = 20f;
    [SerializeField] Transform fireTrans;
    [SerializeField] GameObject Ammo;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }
    void Fire()
    {
        GameObject Go = Instantiate(Ammo, fireTrans.position, Quaternion.identity, this.transform);
        Go.GetComponent<Rigidbody2D>().AddForce(this.transform.InverseTransformVector(Vector3.up) * 15, ForceMode2D.Impulse);

    }
   
}
