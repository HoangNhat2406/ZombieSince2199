using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void ShowWinMenu()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SceneMap2"); 
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}