using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    [SerializeField] float maxVelocity = 5f;
    private float xInput, yInput;

    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float forceX = 0f; float forcey = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.y);

        xInput = Input.GetAxis("Horizontal");

        if (xInput > 0)
        {
            if (velocity < maxVelocity)
                forceX = speed * Time.fixedDeltaTime;
        }
        else if (xInput < 0)
        {
            if (velocity < maxVelocity)
                forceX = -speed * Time.fixedDeltaTime;
        }
        yInput = Input.GetAxis("Vertical");
        if (yInput > 0)
        {
            if (velocity < maxVelocity)
                forcey = speed * Time.fixedDeltaTime;
        }
        else if (yInput < 0)
        {
            if (velocity < maxVelocity)
                forcey = -speed * Time.fixedDeltaTime;
        }
        
        rigidbody2D.AddForce(new Vector2(forceX, forcey),ForceMode2D.Impulse);

    }
}
