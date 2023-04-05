using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMoveDown : MonoBehaviour
{
    private Vector2 targetEnemy;
    private Vector2 targetCam;
    public int speed = 5;
    float duration = 1.0f;
    float minimum = -5.88f;
    float maximum = 0.28f;   
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        targetEnemy = new Vector2(8.76f, -23.3f);
        startTime = Time.time;
    }

    void Update()
    {
        if(GameManager.atTop) {
        transform.position = new Vector2(8.76f, Mathf.PingPong(Time.time, 6.16f)-5.88f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.atTop = false;
        print(other.gameObject.tag);
        if(other.gameObject.tag == "Player") {
            GameManager.ChangeDeathZone(-30);
            StartCoroutine(StartMoving());
        }
    }

    IEnumerator StartMoving() {
        while(true) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetEnemy, step);
            yield return new WaitForSeconds(.01f);
        }
    }
}
