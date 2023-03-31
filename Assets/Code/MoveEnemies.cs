using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    GameObject movingBlock;
    GameObject movingEnemy;
    private Vector2 targetBlock;
    private Vector2 targetEnemy;
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        movingBlock = GameObject.FindGameObjectWithTag("MovingBlock");
    //    .GetComponent<Rigidbody2D>(); 
        movingEnemy = GameObject.FindGameObjectWithTag("MovingShooter");
        targetBlock = new Vector2(0.17f, -1.76f);
        targetEnemy = new Vector2(8.76f, -3.27f);
    }

    IEnumerator StartMoving() {
        int startNumBullets = GameManager.getBulletNum();
        int currentNumBullets;

        while(true) {
            currentNumBullets = GameManager.getBulletNum();
            float step = speed * Time.deltaTime;
            if(currentNumBullets < startNumBullets + 4) {
            GameManager.ReduceSpeedTo(150);
            }
            else{
                GameManager.ResetSpeed();
            }
            movingBlock.transform.position = Vector2.MoveTowards(movingBlock.transform.position, targetBlock, step);
            movingEnemy.transform.position = Vector2.MoveTowards(movingEnemy.transform.position, targetEnemy, step);
            yield return new WaitForSeconds(.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            print("baby nom noms");
            movingBlock.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            StartCoroutine(StartMoving());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
