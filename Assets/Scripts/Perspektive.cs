using UnityEngine;

public class Perspektive : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        float targetAspectRatio = 16f / 9f; // 16:9 Verhältnis
        float currentAspectRatio = (float)Screen.width / Screen.height;

        // Passe die Kamera an, wenn das Verhältnis nicht stimmt
        if (currentAspectRatio != targetAspectRatio)
        {
            Camera.main.aspect = targetAspectRatio;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetMouseButtonDown(0))
        {
            SwitchCamera();
            
            float targetAspectRatio = 16f / 9f; // 16:9 Verhältnis
            float currentAspectRatio = (float)Screen.width / Screen.height;

            // Passe die Kamera an, wenn das Verhältnis nicht stimmt
            if (currentAspectRatio != targetAspectRatio)
            {
                Camera.main.aspect = targetAspectRatio;
            }
        }
    }

    void SwitchCamera()
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].gameObject.SetActive(true);
    }
}

/*
using UnityEngine;
using System.Collections;

public class Perspektive : MonoBehaviour
{
    public Camera[] cameras;

    public float transitionTime = 1.0f;

    private int currentCameraIndex = 0;

    void Start()
    {
        // Deaktiviere alle Kameras außer der ersten
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Starte den Übergang zu einer neuen Kamera
            StartCoroutine(SwitchCamera());
        }
    }

    IEnumerator SwitchCamera()
    {
        // Deaktiviere die aktuelle Kamera
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].gameObject.SetActive(true);
        // Übergangszeit
        yield return new WaitForSeconds(transitionTime);
        // Coroutine-Verhalten (optional)
        StopCoroutine(SwitchCamera());
    }
}
*/