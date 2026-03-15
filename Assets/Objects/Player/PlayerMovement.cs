using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private GameActions gameActions;

    public float moveSpeed = 7.5f;

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
