using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public static float moveSpeed = 5f;

    bool canMove;



    private float horizontal;
    private float vertical;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

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