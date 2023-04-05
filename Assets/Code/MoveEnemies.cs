using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemies : MonoBehaviour
{
    GameObject movingBlock;
    GameObject movingEnemy;
    GameObject invisblock;
    GameObject[] fallingBlocks;
    GameObject[] downarrows;
    private Vector2 targetBlock;
    private Vector2 targetEnemy;
    public int speed = 5;
    private bool blocksDeleted = false;
    // Start is called before the first frame update
    void Start()
    {
        movingBlock = GameObject.FindGameObjectWithTag("MovingBlock");
    //    .GetComponent<Rigidbody2D>(); 
        movingEnemy = GameObject.FindGameObjectWithTag("MovingShooter");
        fallingBlocks = GameObject.FindGameObjectsWithTag("FallingBlocks");
        downarrows = GameObject.FindGameObjectsWithTag("DownHint");
        invisblock = GameObject.FindGameObjectWithTag("Invis");
        targetBlock = new Vector2(0f, -1.8f);
        targetEnemy = new Vector2(8.76f, -3.27f);
    }

    IEnumerator StartMoving() {
        int startNumBullets = GameManager.getBulletNum();
        int currentNumBullets;

        while(true) {
            currentNumBullets = GameManager.getBulletNum();
            float step = speed * Time.deltaTime;
            print("hello" + currentNumBullets);
            print(startNumBullets);
            if((currentNumBullets < startNumBullets + 4) && !GameManager.getResetStatus()) {
                print("hi");
            GameManager.ReduceSpeedTo(150);
            }
            else {
                print("bye");
                GameManager.ResetSpeed();
            }
            movingBlock.transform.position = Vector2.MoveTowards(movingBlock.transform.position, targetBlock, step);
            movingEnemy.transform.position = Vector2.MoveTowards(movingEnemy.transform.position, targetEnemy, step);
            invisblock.GetComponent<SpriteRenderer>().enabled = true;
            if(!blocksDeleted) {
                foreach(GameObject block in fallingBlocks) {
                    block.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -500000),ForceMode2D.Impulse);
                }
                StartCoroutine(DeleteFallingBlocks());
            }
            yield return new WaitForSeconds(.01f);
        }
    }

    IEnumerator DeleteFallingBlocks() {
        yield return new WaitForSeconds(2f);
        blocksDeleted = true;
        Destroy(fallingBlocks[0]);
        Destroy(fallingBlocks[1]);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            print("baby nom noms");
            GameManager.atTop = false;
            downarrows[0].GetComponent<SpriteRenderer>().enabled = true;
            downarrows[1].GetComponent<SpriteRenderer>().enabled = true;
            movingBlock.transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            GameManager.changeResetStatus(false);
            StartCoroutine(StartMoving());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
