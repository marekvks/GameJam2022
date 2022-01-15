using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed = 500f;

    private float vertical;
    private Vector3 mousePos;

    public Camera cam;

    private bool canMove = false;

    private float destination;

    private Ray ray;
    private RaycastHit2D hit;

    private void Start()
    {
    }

    void Update()
    {

        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Vertical") == 1)
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
            rb.velocity = new Vector2(destination * moveSpeed * Time.fixedDeltaTime, vertical * moveSpeed * Time.fixedDeltaTime);
        }
    }
}