using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovemnt : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] bool alive;

    [Header("Movement")]
    [SerializeField] float speed = 0.2f;
    [SerializeField] float startMove = 2f, timer = 0.5f;
    private Vector3 pos;

    [Header("Side Movement")]
    [SerializeField] bool moveRight, moveSide;
    [SerializeField] float xSpeed;
    [SerializeField] float sideTimer = 0.5f, timerMultiliyer = 0.25f, restTimer = 0.5f;


    void Start()
    {
        timer = startMove;
        alive = true;
        moveSide = true;

        pos = transform.position;
    }

    void Update()
    {
        if (!alive)
            return;

        //Death
        Drop();

        if (transform.position.y < -6f)
        {
            Death();
        }

        // Move
        SideMovement();

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Death();
        }    
    }

    void SideMovement()
    {
        if (!moveSide)
            return;

        sideTimer -= Time.deltaTime * timerMultiliyer;

        if(sideTimer <= 0f)
        {
            sideTimer = restTimer;

            moveRight = !moveRight;
        }

        if (moveRight)
            pos += new Vector3(xSpeed * Time.deltaTime, 0f, 0f);
        else
            pos -= new Vector3(xSpeed * Time.deltaTime, 0f, 0f);
    }

    void Drop ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            moveSide = true;

            pos = transform.position;
            Vector3 position = new Vector3(0, speed, 0);

            pos += transform.rotation * position;
        }
    }

    void Death ()
    {
        alive = true;
        Destroy(gameObject);
    }   
}
