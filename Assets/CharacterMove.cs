using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {
    Rigidbody2D rb;

    float moveAccel = 20.0f;
    float moveSpeed = 3.0f;
    float jumpForce = 5.0f;
    bool isGrounded = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        CheckIfGrounded();
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x >-5)
            {
                rb.AddForce(new Vector2(-moveAccel, 0), ForceMode2D.Force);
            }
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (rb.velocity.x < 5)
            {
                rb.AddForce(new Vector2(moveAccel, 0), ForceMode2D.Force);
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
        }


    }

    void CheckIfGrounded()
    {
        RaycastHit2D rc = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - .501f), Vector2.down, .05f,8);

        if (rc.collider!=null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
