using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button qButton;

    public static string previousSceneName;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Goal.count = 0;
        Earth.count = 0;
        previousSceneName = scene.name;
        
        if (qButton != null)
        {
            int currentQualityLevel = QualitySettings.GetQualityLevel();
            string currentQualityName = QualitySettings.names[currentQualityLevel];
            qButton.GetComponentInChildren<Text>().text = currentQualityName;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Option()
    {
        SceneManager.LoadScene(4);
    }

    public void Quality()
    {
        int currentQualityLevel = QualitySettings.GetQualityLevel();
        string currentQualityName = QualitySettings.names[currentQualityLevel];
        qButton.GetComponentInChildren<Text>().text = currentQualityName;

        int maxQualityLevel = 5;
        if (currentQualityLevel < maxQualityLevel)
        {
            QualitySettings.SetQualityLevel(currentQualityLevel + 1);
        }
        else
        {
            QualitySettings.SetQualityLevel(0);
        }
    }

    public void ResetData()
    {

    }

    public void LoadLevel1()
    {
        // Lade Level 1
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        // Lade Level 2
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        // Lade Level 3
        SceneManager.LoadScene(3);
    }

    public void LoadLevel1Tut()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadLevel2Tut()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadLevel3Tut()
    {
        SceneManager.LoadScene(7);
    }
}