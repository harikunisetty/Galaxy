using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 1200f;
    [SerializeField] float maxVelocity = 5f;
    private float xInput;

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
        float forceX = 0f;
        float velocity = Mathf.Abs(rigidbody2D.velocity.x);

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
        rigidbody2D.AddForce(new Vector2(forceX, 0f ),ForceMode2D.Impulse);

    }
}
