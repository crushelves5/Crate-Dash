using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public Text timerText;
    public Text scoreText;
    public float timer = 120;
    float nextSpawnTime;
    float timeBetween = 1f;
    public GameObject gameOverScreen;
    ScoreManager scoremanager;
	// Use this for initialization
	void Start () {
        
      // timerText.text =  time.ToString();
        nextSpawnTime = Time.time + timeBetween;
        scoremanager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (timerText != null)
        {


            if (Time.time > nextSpawnTime)
            {
                if (timer != 0)
                {
                    timer--;
                    timerText.text = timer.ToString();
                    nextSpawnTime = Time.time + timeBetween;
                }
                else
                {
                    GameOver();
                }
            }

            

        }
	}

    void GameOver()
    {
        Time.timeScale = 0f;
        scoreText.text = scoremanager.score.ToString()+ " Points";
        gameOverScreen.SetActive(true);

    }
}
