using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_test : MonoBehaviour
{

    public int speed = 10;

    public int jumpForce = 700;

    public int bulletForce = 500;

    public GameObject bulletPrefab;

    public Transform spawnPoint;

    public AudioClip shootSnd;

    public LayerMask whatIsGround;

    public Transform feet;

    bool grounded = false;

    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);

        float xScale = transform.localScale.x;
        if ((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .25f, whatIsGround);
        _animator.SetBool("Grounded", grounded);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            _audioSource.PlayOneShot(shootSnd);

            _animator.Play("Attack");
            
            GameObject newBullet =  Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

            if (transform.localScale.x < 0) 
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletForce, 0));
            }
            else
            {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 0));
            }
        }
    }
}
