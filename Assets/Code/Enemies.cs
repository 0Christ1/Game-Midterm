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
        StartCoroutine(EnemyMove());
    }
    
    private void Update() 
    {
        if (player.position.x > transform.position.x && transform.localScale.x < 0 || player = position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    IEnumerator EnemyMove()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            _rigidbody.AddForce(new Vector2(transform.localScale.x * 100, 100));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        _animator.SetTrigger("Die");
        Destroy(gameObject, .15f);
    }
}
