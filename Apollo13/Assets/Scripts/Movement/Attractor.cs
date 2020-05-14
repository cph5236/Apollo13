using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private float G = 5;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach(Attractor attractor in attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float dist = direction.magnitude;

        float forceMag = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(dist, 2);

        Vector2 force = direction.normalized * forceMag;

        rbToAttract.AddForce(force);
    }
}
