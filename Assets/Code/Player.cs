using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 10;
    public int jumpForce = 700;
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
        float xSpeed = Input.GetAxis("Horizontal")*speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        // float xpos = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        // Vector2 pos = transform.position;
        // pos.x+=xpos;
        // transform.position = pos;
        grounded = Physics2D.OverlapCircle(feet.position,.3f,whatIsGround);
        if(Input.GetButtonDown("Jump")&& grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
