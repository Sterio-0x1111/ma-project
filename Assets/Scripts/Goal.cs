using System.Collections;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObjekt;

    private Renderer rendererO;

    public static bool isTriggerOn = false;

    void Start()
    {
        rendererO = spawnObjekt.GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kugel"))
        {
            isTriggerOn = true;
            StartCoroutine(MoveObject());
        }
    }

    IEnumerator MoveObject()
    {
        float duration = 3f;
        float elapsed = 0f;

        // Deaktiviert den Renderer des Spawn-Objekts, um es unsichtbar zu machen
        rendererO.enabled = false;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Verschiebt das Spawn-Objekt an eine neue Position
        GameObject spawn = GameObject.Find("Spawn");
        spawnObjekt.transform.position = spawn.transform.position;
        rendererO.enabled = true;
    }
}
