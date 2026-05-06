using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{


    public float speed;
    Rigidbody physic; 
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        //velocity veya addforce
        physic.velocity = transform.forward*speed;//transforma z yönünde ilerlet demek
    }


}
