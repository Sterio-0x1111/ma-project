using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn;

    [SerializeField]
    private Attractor attractor;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Collectible collectibleManager;

    private void Start()
    {
        attractor = GetComponent<Attractor>();
        Attractor.ManuelEnable(attractor);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn") && other.gameObject.name != "SpielBereich")
        {
            ResetPlayer();
            // Aufruf der Reset-Methode des Collectible
            collectibleManager.ResetCollectibles();
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Respawn") && other.gameObject.name == "SpielBereich")
        {
            ResetPlayer();
            collectibleManager.ResetCollectibles();
        }
    }

    private void ResetPlayer()
    {
        transform.position = spawn.transform.position;
        transform.eulerAngles = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
