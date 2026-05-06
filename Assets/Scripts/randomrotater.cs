using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotater : MonoBehaviour
{
    public int speed;
    Rigidbody physic;
    void Start()
    {
        physic = GetComponent<Rigidbody>();

        physic.angularVelocity = Random.insideUnitSphere*speed;
    }


}
