using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Rigidbody2D rb;

    public Camera cam;

    public float degree = 90f;
    
    Vector2 mousePos;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 direction = rb.position - mousePos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - degree;
        rb.rotation = angle;
    }
}
