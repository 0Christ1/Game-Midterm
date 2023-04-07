using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 10;
    public int jumpForce = 700;

    public int bulletForce = 500;
    private Rigidbody2D _rigidbody;
    private Animator  _animator;

    public LayerMask whatIsGround;
    public Transform feet;
    bool grounded = false;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        
        float xSpeed = Input.GetAxis("Horizontal")*speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        
        // folat xScale = transform
        // if(speed < 0&&)
        // {

        // }
        // if(Input.GetAxis("Horizontal")<0)
        // {
        //     GetComponent<SpriteRenderer>().flipX = true;
        // } 
        // else 
        // {
        //     GetComponent<SpriteRenderer>().flipX = false;
        // }
        float xScale = transform.localScale.x;
        if((xSpeed <0 && xScale>0)||(xSpeed >0 && xScale <1))
        {
            transform.localScale*=new Vector2(-1,1);
        }

        _animator.SetFloat("Speed",Mathf.Abs(xSpeed));

    }
    // Update is called once per frame
    void Update()
    {
        // float xpos = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        // Vector2 pos = transform.position;
        // pos.x+=xpos;
        // transform.position = pos;
        grounded = Physics2D.OverlapCircle(feet.position,.2f,whatIsGround);
        _animator.SetBool("Grounded",grounded);
        if(Input.GetButtonDown("Jump")&& grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
