using UnityEngine;
using UnityEngine.InputSystem;

public class KugelSkript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -20f)
        {
            RespawnKugel();
        }
    }

    void RespawnKugel()
    {
        // Setze die Position der Kugel auf die ursprüngliche Position
        transform.position = initialPosition;

        // Setze die Geschwindigkeit auf null, um unerwünschte Bewegung zu verhindern
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}