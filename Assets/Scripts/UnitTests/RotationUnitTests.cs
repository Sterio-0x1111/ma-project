using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationUnitTests : MonoBehaviour
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

    // Tests für den Betrieb
    void Update()
    {
        Vector3 deviceTilt = Input.acceleration;
        Vector3 rotation = new Vector3(-deviceTilt.y, 0f, deviceTilt.x + 90);

        // Erzeugt die Zielrotation basierend auf der Neigung des Geräts
        Quaternion targetRotation = Quaternion.Euler(rotation * -90f);

        // Dämpft die Rotation
        rb.rotation = Quaternion.Lerp(rb.rotation, initialRotation * targetRotation, Time.deltaTime * damping);
        Vector3 r = new Vector3(deviceTilt.y, 0f, -deviceTilt.x);
        String i = rb.rotation.ToString() + initialRotation * targetRotation + Time.deltaTime* damping;
        Debug.Log(i);
    }
}