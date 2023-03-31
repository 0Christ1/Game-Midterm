using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed = 0.2f;
    public float playerX = -7.8f;
    public GameObject dst;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x >= playerX)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dst.transform.position, step);
        }
    }
}
