using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public static float moveSpeed;
    private float walkSpeed = 5f;
    private float runSpeed = 7f;

    bool canMove;

    private float vertical;

    private void Start()
    {
        moveSpeed = walkSpeed;
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = runSpeed;
        } else
        {
            moveSpeed = walkSpeed;
        }

        if (vertical == 1)
        {
            canMove = true;
        } else
        {
            canMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += transform.right * moveSpeed * Time.fixedDeltaTime;
        }
    }
}