using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Attractor : Attractor
{
    public bool orbit;
    public Attractor Attractor_To_Orbit;
    
    private void Start()
    {
        if (orbit)
            SetOrbitSpeed(); //sets the 
    }

    private void SetOrbitSpeed()
    {
        //v = SQRT(G * M / R)
        Vector2 direction = body.position - Attractor_To_Orbit.body.position;
        float dist = direction.magnitude;

        // get velocity required to orbit the mass
        float velocity = Mathf.Sqrt(G * Attractor_To_Orbit.body.mass / dist);

        float force = body.mass * velocity/2f; //get instantantious acceleration

        Vector2 forcevector = new Vector2(direction.y, -direction.x) * force; //force to start orbit
        float forceMag = G * (body.mass * Attractor_To_Orbit.body.mass) / Mathf.Pow(dist, 2);
        Vector2 forceOfAttractor = direction.normalized * forceMag;

        body.AddForce(forcevector+forceOfAttractor); 
        

    }
}
