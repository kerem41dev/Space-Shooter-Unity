using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public GameObject shotspawn;

    AudioSource audioPlayer;
    Rigidbody physic;
    
    [SerializeField] int speed;
    [SerializeField] int tilt;
    [SerializeField] float nextfire;
    [SerializeField] float firerate;

    public Boundary boundary;
    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();//sese erişmek için bağlantı yaptık
    }
    void FixedUpdate()
    {


        float movehorizontal = Input.GetAxis("Horizontal");//yatay
        float movevertical = Input.GetAxis("Vertical");//dikey

        Vector3 movement = new Vector3(movehorizontal, 0, movevertical);
        physic.velocity = movement * speed;

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax),//değişkeni  belirli bir aralıkta tutar
            0,
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)
            );

        physic.position = position;

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt);//a ve d batığında eğim veren 
    }// qua zaten döndürür
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextfire)//saniye dengesi için
        {
            nextfire = Time.time+firerate;
            Instantiate(shot, shotspawn.transform.position, shotspawn.transform.rotation);//mermi oluşturur
            audioPlayer.Play();
        }

    }
}
