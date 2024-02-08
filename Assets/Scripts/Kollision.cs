using UnityEngine;

public class Kollision : MonoBehaviour
{
    private GameObject colliderObjectO;

    private Collider colliderO;

    private GameObject colliderObjectU;

    private Collider colliderU;

    // Start is called before the first frame update
    void Start()
    {
        colliderObjectO = GameObject.Find("KollisionOben");
        colliderO = colliderObjectO.GetComponent<Collider>();
        
        colliderObjectU = GameObject.Find("KollisionUnten");
        colliderU = colliderObjectU.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kugel") && Goal.isTriggerOn)
        {
            colliderO.isTrigger = true;
            colliderU.isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Kugel") && !Goal.isTriggerOn)
        {
            colliderO.isTrigger = false;
            colliderU.isTrigger = true;
        }
    }
}
