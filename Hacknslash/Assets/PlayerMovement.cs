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

    void MovePlayer ()
    {
        Vector2 moveInput = GetMovementInput();
        

        float xSpeed = speed.x;
        float ySpeed = speed.y;
        if (moveInput.x > 0 && speed.x < maxSpeed)
        {
            xSpeed = addAcceleration(speed.x, acceleration);            
        }
        else if (moveInput.x < 0 && speed.x > -maxSpeed)
        {
            xSpeed = addAcceleration(speed.x, -acceleration);            
        }
        else
        {
            if (speed.x > deceleration * Time.deltaTime)
            {
                xSpeed = addDeceleration(speed.x, -deceleration);                
            }
            else if (speed.x < -deceleration * Time.deltaTime)
            {
                xSpeed = addDeceleration(speed.x, deceleration);                
            }
            else
            {
                xSpeed = 0;
            }
        }

        if (moveInput.y > 0 && speed.y < maxSpeed)
        {
            ySpeed = addAcceleration(speed.y, acceleration);            
        }
        else if (moveInput.y < 0 && speed.y > -maxSpeed)
        {
            ySpeed = addAcceleration(speed.y, -acceleration);
        }
        else
        {
            if (speed.y > deceleration * Time.deltaTime)
            {
                ySpeed = addDeceleration(speed.y, -deceleration);                
            }
            else if (speed.y < -deceleration * Time.deltaTime)
            {
                ySpeed = addDeceleration(speed.y, deceleration);    
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

    float addAcceleration(float speed, float acceleration)
    {
        return speed + acceleration * Time.deltaTime;
    }

    float addDeceleration(float speed, float deceleration)
    {
        return speed + deceleration * Time.deltaTime;
    }
}
