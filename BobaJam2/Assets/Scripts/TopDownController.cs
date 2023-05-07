using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool canwalk = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if(canwalk)
        {
            movement = new Vector2(horizontalInput, verticalInput).normalized;
            rb.velocity = movement * moveSpeed;
            if (rb.velocity.x < 0)
            {
                gameObject.transform.localScale = new Vector3(1.5F, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            if (rb.velocity.x > 0)
            {
                gameObject.transform.localScale = new Vector3(-1.5F, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
       
    }
}
