using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kollision : MonoBehaviour
{
    private bool routine = false;
    private bool Collider = false;
    private Collider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kugel") && !routine)
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kugel") && !routine)
        {
            myCollider.isTrigger = false;
        }
    }
}
