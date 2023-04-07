using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifetime = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }
}
