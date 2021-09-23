using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ove : MonoBehaviour
{
    [Header("Ai")]
    public bool alive;

    [Header("MoveMent")]

    [SerializeField] float moveSpeed = 0.2f;
    public float startMove = 2f, timer = 0.5f;
    public Vector3 pos;

    [Header("SideMovement")]
    [SerializeField] bool moveRight, moveSide;
    [SerializeField] float xSpeed;
    [SerializeField] float startTimer=0.5f,timerMultiliyer=0.25f, restTimer = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        moveSide = true;
        alive=true;
        timer = startMove;

        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
            return;

        Down();

        if (transform.position.y < -6)
        {
            Dead();
        }

        SideMovement();
        transform.position = pos;
    }
    public void Down()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            moveSide = false;
            pos = transform.position;
            Vector3 position = new Vector3(0f, moveSpeed, 0f);
            pos += transform.rotation * position;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    public void SideMovement()
    {
        if (!moveSide)
            return;
        if (!moveSide)
            return;

        startTimer -= Time.deltaTime * timerMultiliyer;

        if (startTimer <= 0f)
        {
            startTimer = restTimer;

            moveRight = !moveRight;

        }
        if (moveRight)
            pos += new Vector3(xSpeed * Time.deltaTime, 0f, 0f);
        else
            pos -= new Vector3(xSpeed * Time.deltaTime, 0f, 0f);


    }
    public void Dead()
    {
        alive = true;
        Destroy(gameObject);
    }
}
