using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public GameObject explosion;

    Transform player;

    Animator _animator;

    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        _animator.SetTrigger("Die");
        Destroy(gameObject, .15f);
    }
}
