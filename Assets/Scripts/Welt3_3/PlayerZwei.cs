using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerZwei : MonoBehaviour
{
    // Der Punkt, an dem die Kugel respawnen soll
    public GameObject respawnPoint;

    private void Update()
    {
        if (transform.position.y < -80f)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.transform.position;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        }
    }
}