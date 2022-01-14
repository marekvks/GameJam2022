using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 5f;

    float horizontal;
    float vertical;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");    // value a key == -1, d key == 1
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime);  // it's better to use FixedUpdate because working with physics inside Update method is'nt good
        animator.SetFloat(1, horizontal);
        animator.SetFloat(2, vertical);
        animator.SetFloat(3, moveSpeed);
    }
}
