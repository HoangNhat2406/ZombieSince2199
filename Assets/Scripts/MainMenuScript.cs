using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Call this from a UI Button (OnClick)
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Call this from a UI Button (OnClick)
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Useful for testing in Editor
        Application.Quit();
    }
}