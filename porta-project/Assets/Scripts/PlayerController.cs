using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float horizontal;
    public float speed;
    public float jumpPower = 4f;
    bool isFacingRight = false;
    bool isJumping;
    bool isGrounded;

    Rigidbody2D rb;

    Animator anim;

    private GameObject currentPortal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        flipSprite();

        if (Input.GetButtonDown("Jump") && !isJumping && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentPortal != null)
            {
                transform.position = currentPortal.GetComponent<portalScript>().getDestination().position;

            }
       }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("xvelocity", Math.Abs(rb.velocity.x));
    }

    void flipSprite()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        isGrounded = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("portal"))
        {
            currentPortal = collision.gameObject;
            //transform.position = currentPortal.GetComponent<portalScript>().getDestination().position;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("portal"))
        {
            if (collision.gameObject == currentPortal)
            {
                currentPortal = null;
            }
        }
    }
}
