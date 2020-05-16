using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Attractor : Attractor
{
    public bool orbit;
    public bool clockwise;
    public Attractor Attractor_To_Orbit;

    public Transform center;
    private Vector3 axis = Vector3.forward;
    private Vector2 desiredPosition;
    private float radius;
    private float radiusSpeed = 250000f;
    public float rotationSpeed = 80.0f;

    private void Start()
    {
        if (orbit)
        {
            center = Attractor_To_Orbit.transform;
            //transform.position = (transform.position - center.position).normalized * radius + center.position;
            
            Vector2 direction = body.position - Attractor_To_Orbit.body.position;
            radius = direction.magnitude;
        }

    }

    private void FixedUpdate()
    {
        if (orbit)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector2.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        base.FixedUpdate();
    }

}
