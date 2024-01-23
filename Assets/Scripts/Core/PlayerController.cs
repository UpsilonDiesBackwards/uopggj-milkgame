using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public float moveSpeed;
    private bool isPlayerMoving;
    private Vector2 lastMove;

    void Start()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isPlayerMoving = false;

        float input_hor = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(input_hor, 0f);

        movement *= moveSpeed;

        rb.velocity = new(movement.x, rb.velocity.y);

        if (input_hor > 0.5f || input_hor < -0.5f ) {
            isPlayerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = new(rb.velocity.x, 10f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMoving?", isPlayerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
