using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameActions gameActions;
    private Animator animator;

    public int moveSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        gameActions.Enable();
    }
    void OnDisable()
    {
        gameActions.Disable();
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameActions = new GameActions();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.Instance.canMove)
        {
            rb.linearVelocity = gameActions.Character.Move.ReadValue<Vector2>() * moveSpeed;
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, 0f);
        }
    }

    private void Update()
    {
        if (GameManager.Instance.canMove)
        {
            if (gameActions.Character.Move.ReadValue<Vector2>() != new Vector2(0, 0))
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
