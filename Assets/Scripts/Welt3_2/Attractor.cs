using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float g = 667.4f;

    public Rigidbody rb;

    public static List<Attractor> attractorsList;

    void FixedUpdate()
    {
        foreach (Attractor attractor in attractorsList)
        {
            if (attractor != this)
            {
                if (attractor != null)
                {
                    Attract(attractor);
                }
                
            }
        }
    }

    public static void ManuelEnable(Attractor gameObject)
    {
        if (attractorsList == null)
        {
            attractorsList = new List<Attractor>();
        }

        attractorsList.Add(gameObject);
    }

    public static void ManuelDisable(Attractor gameObject)
    {
        attractorsList.Remove(gameObject);
    }

    public void Attract(Attractor objektToAttract)
    {
        Rigidbody rbToAttract = objektToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f)
        {
            return;
        }

        float forceMagnitude = (float)(g * (rb.mass * rbToAttract.mass) / Math.Pow(distance, 2));
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
