using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
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
}
