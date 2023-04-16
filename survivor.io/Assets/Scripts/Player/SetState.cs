using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetState : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        playerBody = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBody.velocity.magnitude > 0)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", true);
        }
        if (playerBody.velocity.magnitude == 0)
        {
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", true);
        }
        if (playerBody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (playerBody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
