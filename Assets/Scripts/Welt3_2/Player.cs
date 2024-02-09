using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn;

    [SerializeField]
    private Attractor attractor;

    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        attractor = GetComponent<Attractor>();
        Attractor.ManuelEnable(attractor);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn") && other.gameObject.name != "SpielBereich")
        {
            transform.position = spawn.transform.position;
            transform.eulerAngles = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn") && other.gameObject.name == "SpielBereich")
        {
            transform.position = spawn.transform.position;
            transform.eulerAngles = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
