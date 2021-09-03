using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovemnt : MonoBehaviour
{
    public float speed = 0.2f;
    [SerializeField] float startMove= 2f;
    [SerializeField] float timer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = startMove;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
           

            Vector3 pos = transform.position;
            Vector3 position = new Vector3(0, speed, 0);

            pos += transform.rotation * position;

            transform.position = pos;
        }
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
   
}
