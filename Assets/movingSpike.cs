using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingSpike : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.2f;
    public GameObject dst;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x <= -6.5 && player.transform.position.y >= 1.04)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dst.transform.position, step);
        }
    }
}
