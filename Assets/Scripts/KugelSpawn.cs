using UnityEngine;
using UnityEngine.InputSystem;

public class KugelSpawn : MonoBehaviour
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
            RespawnKugel(initialPosition);
        }
    }

    public void RespawnKugel(Vector3 position)
    {
        transform.position = position;

        // Setzt die Geschwindigkeit auf null, um unerwünschte Bewegung zu verhindern
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}