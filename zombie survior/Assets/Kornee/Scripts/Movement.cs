using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    public float horizontal;
    float vertical;

    public float WalkSpeed = 20.0f;

    public bool lookRight = true; 
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        if (horizontal > 0 && !lookRight)
        {
            flip();
        }
        if (horizontal < 0 && lookRight)
        {
            flip();
        }

    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * WalkSpeed, vertical * WalkSpeed);
    }
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        lookRight = !lookRight;
    }
}
