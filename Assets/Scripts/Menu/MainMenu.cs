using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject popupPrefabLevel1;

    public GameObject popupPrefabLevel2;
    
    public GameObject popupPrefabLevel3;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLevel1()
    {
        // Zeigt Popup für Level 1 an
        ShowPopup(popupPrefabLevel1, 1);
    }

    public void LoadLevel2()
    {
        // Zeigt Popup für Level 2 an
        ShowPopup(popupPrefabLevel2, 2);
    }

    public void LoadLevel3()
    {
        // Zeigt Popup für Level 3 an
        ShowPopup(popupPrefabLevel3, 3);
    }

    void ShowPopup(GameObject popupPrefab, int levelIndex)
    {
        GameObject popup = Instantiate(popupPrefab, Vector3.zero, Quaternion.identity);

        // Startet das Laden des Levels nach dem Popup
        StartCoroutine(LoadLevel(popup, levelIndex));
    }

    IEnumerator LoadLevel(GameObject popup, int levelIndex)
    {
        yield return new WaitUntil(() => !popup.activeSelf);
        
        // Lädt das entsprechende Level
        SceneManager.LoadScene(levelIndex);
    }
}
