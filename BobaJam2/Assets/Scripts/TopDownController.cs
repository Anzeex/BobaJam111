using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * moveSpeed;
    }
}
