using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnJump()
    {
        Debug.Log("Jump Pressed");
    }
    public void OnPause()
    {
        Debug.Log("Pause Pressed");
        if (UIManager.Instance == null)
            Debug.Log("UIManager Instance is null");
        else    
            UIManager.Instance.TogglePauseMenu();
        GameManager.Instance.PauseGame();
    }
}
