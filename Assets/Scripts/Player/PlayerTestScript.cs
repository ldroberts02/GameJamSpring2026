
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTestScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    public float sizeFloat = 0.5f;
    public float moveSpeed = 5f;
    float jumpTimer = 0.0f;
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpTimer > 0f)
        {
            jumpTimer -= Time.deltaTime;
        }
    }
    public void OnJump()
    {

        if (IsGrounded() && jumpTimer <= 0f)
        {
            jumpTimer = 0.5f; //to prevent spamming jumps
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    public void OnMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        rb.linearVelocity = new Vector2(inputVector.x * moveSpeed, rb.linearVelocity.y);
    }
    public void OnPause()
    {
        if (GameManager.Instance.isGamePaused)
        {
            UIManager.Instance.DisablePauseMenu();
            GameManager.Instance.UnpauseGame();
            return;
        }
        else if (!GameManager.Instance.isGamePaused)
        {
            if (UIManager.Instance == null)
                Debug.Log("UIManager Instance is null");
            else
                UIManager.Instance.EnablePauseMenu();
            GameManager.Instance.PauseGame();
        }


    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - sizeFloat), Vector2.down, 0.1f);

        if (hit.collider != null)
        {
            //Debug.Log("Grounded: " + hit.collider.name);
            //Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - sizeFloat), Vector2.down, Color.red);
            return true;
        }
        else
        {
            Debug.Log("Not Grounded");
            return false;
        }

    }
}
