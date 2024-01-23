using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    /*
     * PLAYER MOVEMENT VARAIBLES ::
     * moveSpeed: the speed of which the player moves at
     * isPlayerMoving: boolean what states if player is moving
     * lastMove: the last move and direction the player was at
     */
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

        Vector2 movement = new Vector2(input_hor, 0f).normalized;

        movement *= moveSpeed;

        // Move
        rb.velocity.x = movement.x;

        if (input_hor > 0.5f || input_hor < -0.5f ) {
            isPlayerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("isMoving?", isPlayerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
