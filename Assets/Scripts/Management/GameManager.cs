using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; //in case the game was paused
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
    void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
        else
        Time.timeScale = 0f;
    }
}
