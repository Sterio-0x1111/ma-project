using UnityEngine;
using TMPro;

public class FPSAnzeige : MonoBehaviour
{
    public TMP_Text fpsText;
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        int fps = Mathf.RoundToInt(1.0f / deltaTime);

        // Aktualisiere den Text im TMP-Text-Element
        fpsText.text = "FPS: " + fps;
    }
}