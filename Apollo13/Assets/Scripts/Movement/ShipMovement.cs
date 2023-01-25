using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float rotateSpeed = 100.0f;
    public float maxSpeed = 100.0f;
    public float currentSpeed = 0.01f;
    public Vector2 frontOfShip;
    public Vector2 backOfShip;

    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frontOfShip = transform.up;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddForce(frontOfShip * currentSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb2d.AddForce(frontOfShip * -currentSpeed);
        }

        //if space bar is pressed
        //increase speed forward

        //if S Pressed
        //decrease speed
    }
}
