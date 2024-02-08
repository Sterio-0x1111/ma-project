using System.Collections;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Frame Settings")]
    int MaxRate = 1000;

    public float TargetFrameRate = 60.0f;

    float currentFrameTime;
    
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = MaxRate;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine("WaitForNextFrame");
    }

    private void Update()
    {
        if (Goal.count == 2)
        {
            // wechsel scene: Hauptmenu
        }
    }

    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / TargetFrameRate;
            var t = Time.realtimeSinceStartup;
            var sleepTime = currentFrameTime - t - 0.01f;
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000));
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
}