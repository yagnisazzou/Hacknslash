using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    protected Rigidbody2D rb;


    private Vector3 speed = Vector3.zero;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float acceleration;
    [SerializeField] protected float deceleration;


    // Start is called before the first frame update
    void Start()
    {

        //Reference calls
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void UpdateMovement ()
    {
        Debug.Log(GetMovementInput());
    }

    void MovePlayer ()
    {
        Vector2 moveInput = GetMovementInput();

        float xSpeed = speed.x;
        float ySpeed = speed.y;
        if (moveInput.x > 0 && speed.x < maxSpeed)
        {
            xSpeed = speed.x + acceleration * Time.deltaTime;
        }
        else if (moveInput.x < 0 && speed.x > -maxSpeed)
        {
            xSpeed = speed.x - acceleration * Time.deltaTime;
        }
        else
        {
            if (speed.x > deceleration * Time.deltaTime)
            {
                xSpeed = speed.x - deceleration * Time.deltaTime;
            }
            else if (speed.x < -deceleration * Time.deltaTime)
            {
                xSpeed = speed.x + deceleration * Time.deltaTime;
            }
            else
            {
                xSpeed = 0;
            }
        }

        if (moveInput.y > 0 && speed.y < maxSpeed)
        {
            ySpeed = speed.y + acceleration * Time.deltaTime;
        }
        else if (moveInput.y < 0 && speed.y > -maxSpeed)
        {
            ySpeed = speed.y - acceleration * Time.deltaTime;
        }
        else
        {
            if (speed.y > deceleration * Time.deltaTime)
            {
                ySpeed = speed.y - deceleration * Time.deltaTime;
            }
            else if (speed.y < -deceleration * Time.deltaTime)
            {
                ySpeed = speed.y + deceleration * Time.deltaTime;
            }
            else
            {
                ySpeed = 0;
            }
        }


        speed = new Vector3(xSpeed, ySpeed, 0);
        transform.position = transform.position + new Vector3(speed.x, speed.y, 0) * Time.deltaTime;
        //rb.MovePosition(transform.position + speed * Time.deltaTime);
        //rb.velocity = transform.position + new Vector3(speed.x, speed.y) * Time.deltaTime;
        return;
    }

    Vector2 GetMovementInput ()
    {
        int xAxis = 0;
        int yAxis = 0;
        if (Input.GetKey(KeyCode.W))
        {
            yAxis = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yAxis = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            xAxis = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xAxis = -1;
        }

        return new Vector2(xAxis, yAxis);
    }

}
