using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static int lives = 3;
    private static int bulletspeed = 600;
    private static int numBulletsShot = 0;
    private static int deathzone = -9;
    private static bool levelReset = true;
    public static bool atTop = true;
    // public TextMeshProUGUI livesUI;

    private void Awake() {
        if(GameObject.FindObjectsOfType<GameManager>().Length > 1) {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        // livesUI.text = "Lives: " + lives;
    }
    public static void ReduceSpeedTo(int value) {
        bulletspeed = value;
    }
    public static void AddBullet() {numBulletsShot += 1;}
    public static int getBulletNum() {return numBulletsShot;}
    public static void resetBullets() {numBulletsShot = 0;}

    public static void ChangeDeathZone(int value) {deathzone = value;}
    public static int getDeathZone() {return deathzone;}
    public static void resetDeathZone() {deathzone = -9;}

    public static void ResetSpeed() {bulletspeed = 600;}
    public static void ResetLives() {lives = 3;}

    public static int getSpeed() {
        return bulletspeed;
    }
    public static int RemoveLife() {
        lives -= 1;
        // livesUI.text = "Lives: " + lives;
        return lives;
    }

    public static bool getResetStatus() {return levelReset;}

    public static void changeResetStatus(bool val) {
        levelReset = val;
    }
    // Update is called once per frame
    public void Update()
    {
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
#endif
    }
}
