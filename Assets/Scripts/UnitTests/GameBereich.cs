using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBereich : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kugel"))
        {
            other.transform.position = spawn.transform.position;
            other.transform.eulerAngles = Vector3.zero;
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
