using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosion;
    Transform player;
    Animator _animator;
    Rigidbody2D _rigidbody;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _animator.SetTrigger("Die");
            Destroy(gameObject, .15f);
            
        }
    }
}
