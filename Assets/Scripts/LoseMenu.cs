using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    // Call this from a UI Button (OnClick)
    public void RetryGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Call this from a UI Button (OnClick)
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // Useful for testing in Editor
        Application.Quit();
    }

    public void Start()
    {
        gameObject.SetActive(false);
    }
}