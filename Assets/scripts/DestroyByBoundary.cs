using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public GameController gameController;
    public GameObject playerExplosion;
    private int scoreValue = 10;

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


    void OnTriggerExit(Collider other)
    {

        if (other.tag == "hazard")

            // int score= System.Int32.Parse(gameController.scoreText.text.ToString());
            //  Debug.Log(gameController.scoreText.text);
            if (gameController.subScore(scoreValue) < 0) // subscore return the new value of score after subtraction
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.gameOver();

                Destroy(other.gameObject);
            }
    }
}