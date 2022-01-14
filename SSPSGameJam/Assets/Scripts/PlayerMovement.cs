using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 500f;

    private float horizontal;
    private float vertical;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime);
    }
}