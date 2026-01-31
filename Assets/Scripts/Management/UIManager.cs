using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Canvas pauseMenuCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); // Destroy the new instance if one already exists
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (pauseMenuCanvas == null)
        {
            Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
            foreach (Canvas canvas in canvases)
            {
                if (canvas.name == "Pause Menu")
                {
                    pauseMenuCanvas = canvas;
                    pauseMenuCanvas.enabled = false;
                    break;
                }
            }
        }
        else
        {
            pauseMenuCanvas.enabled = false;
        }

    }
    void Update()
    {

    }
    public void EnablePauseMenu()
    {
        pauseMenuCanvas.enabled = true;
    }
    public void DisablePauseMenu()
    {
        pauseMenuCanvas.enabled = false;
    }
}
