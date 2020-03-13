using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizSpeed, vertSpeed;

    [SerializeField]
    Transform groundCheck;

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            //idle anim
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(horizSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            //move left anim
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-horizSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            //move right anim
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, vertSpeed);
            //jump anim
        }
        if (Input.GetKey(KeyCode.S))
        {
            //crouch code
        }
    }
}
