using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingpower = 16f;
    private bool isfacingright = true;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask groundlayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") &&IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingpower);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded ()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundlayer);
    }
    private void Flip()
    {
        if ( isfacingright && horizontal < 0f || !isfacingright && horizontal >0f)
        {
            isfacingright = !isfacingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
