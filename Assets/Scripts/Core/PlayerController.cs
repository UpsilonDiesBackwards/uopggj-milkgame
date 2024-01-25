using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Reference")] [SerializeField] private GameObject _graphic;
    
    private Animator anim;
    private Rigidbody2D rb;

    public float moveSpeed;
    private bool isPlayerMoving;
    private Vector2 lastMove;

    [Header("Properties")] private Vector3 origLocalScale;
    public bool freeze = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();    
        rb = GetComponent<Rigidbody2D>();

        origLocalScale = transform.localScale;
    }

    private void FixedUpdate()
    {
       if (!freeze)
       {
            Movement();
       }
    }

    void Movement()
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
        
        // Flip the sprite
        if (input_hor > 0.01f)
        {
            _graphic.transform.localScale = new Vector3(origLocalScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (input_hor < -0.01f)
        {
            _graphic.transform.localScale = new Vector3(-origLocalScale.x, transform.localScale.y, transform.localScale.z);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetBool("isMoving?", isPlayerMoving);
    }
}
