using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;
    private int scoreValue=10;

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
            Debug.Log("Can not find the 'GameController' script");
    }

        


     void OnTriggerEnter(Collider other)
    {
     

        if (other.tag == "boundary")
            return;
        
            //Destroy(other.gameObject);

      //  Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOver();
        }
        if (other.tag != "Player")
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }

            Destroy(other.gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        // if (other.tag == "Bolt")
        //  Destroy(gameObject);

        // else gameController.subScore(scoreValue);
    }

}

