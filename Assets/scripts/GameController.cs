using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public Text scoreText;
    public Text RestartText;
    public Text GameOverText;
    private bool Restart;
    private bool gameover;
    private int score;
    void Start()
    {
        Restart = false;
        gameover = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
       StartCoroutine( SpawnWaves());
    }

     void Update()
    {
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
               Application.LoadLevel(Application.loadedLevel);

            }
        }
        
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                yield return new WaitForSeconds(StartWait);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                
                yield return new WaitForSeconds(SpawnWait);
            }
            if (gameover)
            {
                Restart = true;
                RestartText.text = "Press 'R' to restart the game";
                break;

            }
            yield return new WaitForSeconds(WaveWait);
        }
    }

   public void AddScore(int newScorevalue)
    {
        score += newScorevalue;
        UpdateScore();

    }

    public int subScore(int newScorevalue)
    {
        score -= newScorevalue;
        UpdateScore();
        return score;

    }
    public void UpdateScore()
    {
      scoreText.text=  "score:" + score;

    }
  public  void gameOver()
    {
        gameover = true;
        GameOverText.text = "Game Over";


    }
    
}


