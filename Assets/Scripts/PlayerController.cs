using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 10f;
    private bool isFacingRight = true;
    private Animator anim;
    private float jumpForce = 20;
    private bool isGrounded=true;
    private float groundRadius = 2f;
    Rigidbody2D rb;
    // public LayerMask whatIsGround;
    int layerMask = 1 << 8;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        float move = Input.GetAxisRaw("Horizontal");
        if (isGrounded) {
            anim.SetFloat("Speed", Mathf.Abs(move));
        }
        
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight) {
            Flip();
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, groundRadius, layerMask);

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //   isGrounded = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), groundRadius, layerMask);
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("Ground", false);
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
