using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScript : MonoBehaviour
{
    public GameObject deathPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y <= -7)
        {
            deathPanel.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("spike"))
        {
            deathPanel.SetActive(true);
        }
    }
}
