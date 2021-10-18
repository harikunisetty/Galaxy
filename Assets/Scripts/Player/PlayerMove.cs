using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 40f;
    [SerializeField] float maxVelocity = 5f;

    [Header("Keyboard Input")]
    private float xInput, yInput;

    [Header("Mouse Input")]
    private bool isDragged;
    [SerializeField] Vector3 screenPosition, offset;

    [Header("Touch Input")]
    [SerializeField] float touhcMovespeed = 5f;
    private Vector3 currentDirection;

    [Header("Components")]
    [SerializeField] Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        // Touch
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            switch(touch.phase)
            {
                case TouchPhase.Stationary:
                    transform.position += currentDirection;
                    break;
                case TouchPhase.Moved:
                    currentDirection = touch.deltaPosition * touhcMovespeed;
                    transform.position += currentDirection;
                    break;
                default:
                    currentDirection = Vector3.zero;
                    break;
            }
        }
        */
    }

    void keyboardInput()
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

        rigidbody2D.AddForce(new Vector2(forceX, forcey), ForceMode2D.Impulse);

    }

    private void OnMouseDown()
    {
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
    }

    private void OnMouseDrag()
    {
        Vector3 currentPosition, currentScreenPosition;

        currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
        currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPosition) + offset;

        transform.position = currentScreenPosition;
    }
}
