using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleter : MonoBehaviour
{
    public float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }


    
}
