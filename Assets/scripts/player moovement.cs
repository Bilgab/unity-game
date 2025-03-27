using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    BoxCollider2D boxCol;


    [SerializeField] int moveSpeed = 5;
    [SerializeField] LayerMask ground;

    enum MovementState { idle, running, jumping, falling, doubble_jumping, wall_jumping}
    MovementState state = MovementState.idle;
    // Start is called before the first frame update

    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey("space") && isGrounded())
        {
            jumpSound.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }


        if (rb.velocity.x > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(rb.velocity.x < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)(state));
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "¨Banana")
        {
            transform.position = GameObject.Find("Level2Start").transform.position;
        }
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}
