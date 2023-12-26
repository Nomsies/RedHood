using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 20f;
    public float speed = 8f;
    private float horizontal;
    private bool isFacingRight = true;
    private bool onGround;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundChk;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    void Update ()
    {
        animator.SetFloat("vSpeed", rb.velocity.y);
        animator.SetBool("onGround", onGround);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && onGround)
        {
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        //{
        //   rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}

        Flip();
    }

    private bool isGrounded ()
    {
        return Physics2D.OverlapCircle(groundChk.position, 0.2f, groundLayer);
    }

    private void FixedUpdate ()
    {
        bool wasGrounded = onGround;
        onGround = false;

        if (isGrounded())
        {
            onGround = true;
            if (!wasGrounded)
            {
                animator.SetBool("isJumping", false);
            }
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    private void Flip ()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
