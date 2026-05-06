using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroybycontact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerexplosion;
    private GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();//scripte olaşmak için
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "player")
        {
            Instantiate(playerexplosion, other.transform.position, other.transform.rotation);
            gameController.Gameover();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.UpdateScore();
    }
}
