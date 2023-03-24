using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameObject[] pinkItems;
    public LayerMask whatIsButton;
    public Transform feet;
    bool buttonPressed = false;
    
    void Start()
    {
        pinkItems = GameObject.FindGameObjectsWithTag("Pink");
    }

    void Update() {
        buttonPressed = Physics2D.OverlapCircle(feet.position,.4f,whatIsButton);
        if(buttonPressed) {
            print(buttonPressed);
                foreach(GameObject pinkItem in pinkItems) {
                    Destroy(pinkItem);
                }
                Destroy(gameObject);
            }
        }
}
    // void onCollisionEnter(Collision other) {
    //     print(other.gameObject.tag);    
    //     if(other.gameObject.CompareTag("Feet")) {
    //         foreach(GameObject pinkItem in pinkItems) {
    //             Destroy(pinkItem);
    //         }
    //         Destroy(gameObject);
    //     }
    // }
