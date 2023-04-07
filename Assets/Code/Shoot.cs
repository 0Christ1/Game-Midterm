using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip shootSnd;
    public GameObject bulletfab;
    AudioSource _audiosource;
    GameObject movingEnemy;
    private Vector2 targetEnemy;

    public GameObject explosion;
    GameManager _gamemanager;

    void Start()
    {
       _gamemanager = GameObject.FindObjectOfType<GameManager>();
       _audiosource = GetComponent<AudioSource>();
        targetEnemy = new Vector2(8.65f, -3.27f);
        movingEnemy = GameObject.FindGameObjectWithTag("MovingShooter");
       StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets() {
        // print(movingEnemy);
        // print(targetEnemy);
        while(true) {
            GameObject newbullet = Instantiate(bulletfab, transform.position, Quaternion.identity);
            GameManager.AddBullet();
            _audiosource.PlayOneShot(shootSnd);
            newbullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-(GameManager.getSpeed()), 0));
            yield return new WaitForSeconds(.8f);
            }
        }
    }
