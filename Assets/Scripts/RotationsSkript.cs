using UnityEngine;
using UnityEngine.InputSystem;

public class RotationsSkript : MonoBehaviour
{
    private Rigidbody rb;
    private Quaternion initialRotation;

    [SerializeField]
    private float Damping = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = Quaternion.identity;
    }

    void Update()
    {
        Vector3 deviceTilt = Input.acceleration;
        Vector3 rotation = new Vector3(deviceTilt.y, 0f, -deviceTilt.x);

        // Erzeuge die Zielrotation basierend auf der Neigung des Geräts
        Quaternion targetRotation = Quaternion.Euler(rotation * 90f);

        // Dämpft die Rotation
        rb.rotation = Quaternion.Lerp(rb.rotation, initialRotation * targetRotation, Time.deltaTime * Damping);
    }
}