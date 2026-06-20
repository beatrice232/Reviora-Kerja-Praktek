using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f;
    [SerializeField]private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = 0;
        float y = 0;

        if (Keyboard.current.dKey.isPressed)
            x = -1;
        if (Keyboard.current.aKey.isPressed)
            x = 1;

        if (Keyboard.current.wKey.isPressed)
            y = 1;
        if (Keyboard.current.sKey.isPressed)
            y = -1;

        Vector2 movement = new Vector2(-x, y).normalized;
        rb.linearVelocity = movement * speed;

        if (x == 0 && y == 0)
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (animator != null)
        {
            if (x == 0 && y == 0)
            {
                animator.Play("idle");
            }
            else
            {
                animator.Play("walk");
            }
        }
    }
}