using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 2;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }
}
