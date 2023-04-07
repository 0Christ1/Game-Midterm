using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip hitSnd;
    AudioSource _audiosource;

    public GameObject explosion;
    GameManager _gamemanager;
    public string currLevel;

    public int speed = 10;
    public int jumpForce = 600;
    private Rigidbody2D _rigidbody;

    public LayerMask whatIsGround;
    public Transform feet;
    bool grounded = false;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
       _gamemanager = GameObject.FindObjectOfType<GameManager>();
       _audiosource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            // Destroy(other.gameObject);
            // Destroy(gameObject);
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            // _audiosource.PlayOneShot(hitSnd);            
            if (lives == 0) {
                // Instantiate(explosion, transform.position, Quaternion.identity);
                SceneManager.LoadScene("Start");
                GameManager.ResetLives();
            }
            else{
            SceneManager.LoadScene(currLevel);
            }
        }
    }
    
    IEnumerator EndingScreen() {
        SceneManager.LoadScene("End");
        yield return new WaitForSeconds(.01f);
        SceneManager.LoadScene("Level2");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("spike"))
        {
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            // _audiosource.PlayOneShot(hitSnd);            
            if (lives == 0) {
                // Instantiate(explosion, transform.position, Quaternion.identity);
                SceneManager.LoadScene("Start");
                GameManager.ResetLives();
            }
            else{
            SceneManager.LoadScene(currLevel);
            }
        }
    }    

    void FixedUpdate()
    {
        print(GameManager.getSpeed());
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
        if (transform.position.y < GameManager.getDeathZone()) {
            GameManager.ResetSpeed();
            GameManager.resetBullets();
            GameManager.resetDeathZone();
            int lives = GameManager.RemoveLife();
            // _audiosource.PlayOneShot(hitSnd);            
            if (lives == 0) {
                // Instantiate(explosion, transform.position, Quaternion.identity);
                SceneManager.LoadScene("Start");
                GameManager.ResetLives();
            }
            else{
                SceneManager.LoadScene(currLevel);
            }
        }
        grounded = Physics2D.OverlapCircle(feet.position,.4f,whatIsGround);
        if(Input.GetButtonDown("Jump")&& grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
