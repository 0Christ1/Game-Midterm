using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;

    public int jumpForce = 800;

    private Rigidbody2D _rigidbody;

    public LayerMask whatIsGround;

    public Transform feet;

    bool grounded = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;

        if(Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .25f, whatIsGround);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
