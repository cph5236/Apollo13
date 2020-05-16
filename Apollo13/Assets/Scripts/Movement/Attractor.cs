using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    protected float G = 6.67f;
    public Rigidbody2D body;
    public bool remainStationary;

    protected void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor attractor in attractors)
        {
            if (attractor != this && attractor.remainStationary != true)
                Attract(attractor);
        }
    }

    private void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.body;

        Vector2 direction = body.position - rbToAttract.position;
        float dist = direction.magnitude;

        float forceMag = G * (body.mass * rbToAttract.mass) / Mathf.Pow(dist, 2);

        Vector2 force = direction.normalized * forceMag;

        rbToAttract.AddForce(force);
    }
}
