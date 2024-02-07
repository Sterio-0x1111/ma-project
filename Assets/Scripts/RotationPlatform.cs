using UnityEngine;
using UnityEngine.InputSystem;

public class RotationsPlatform : MonoBehaviour
{
    private Rigidbody rb;

    private Quaternion initialRotation;

    [SerializeField]
    private float damping = 0.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = Quaternion.identity;
    }

    void Update()
    {
        Vector3 deviceTilt = Input.acceleration;

        Vector3 rotation;
        if (Goal.isTriggerOn)
        {
            rotation = new Vector3(deviceTilt.y, 0f, -deviceTilt.x - 90);
        }
        else
        {
            rotation = new Vector3(deviceTilt.y, 0f, -deviceTilt.x);
        }
        
        // Erzeugt die Zielrotation basierend auf der Neigung des Geräts
        Quaternion targetRotation = Quaternion.Euler(rotation * 90f);

        // Dämpft die Rotation
        rb.rotation = Quaternion.Lerp(rb.rotation, initialRotation * targetRotation, Time.deltaTime * damping);
    }
}