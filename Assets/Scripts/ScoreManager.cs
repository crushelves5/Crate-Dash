using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {
    PlayerController playerController;
    public Text scoreUI;
    public float plusPoints = 150;
    public float minuPoints = 75;
    public float score;
	// Use this for initialization
	void Start () {
        score = 0;
       playerController = FindObjectOfType<PlayerController>();
        FindObjectOfType<DepositManager>().Match += AddPoints;
        FindObjectOfType<DepositManager>().UnMatch += LosePoints;
        
	}

    private void Update()
    {
        if(score > 2000)
        {
            playerController.moveSpeed = 20;

        }
        else if(score > 1500)
        {
            playerController.moveSpeed = 18;

        }
        else if(score > 1000)
        {
            playerController.moveSpeed = 16;
        }
        else if (score > 500)
        {
            playerController.moveSpeed = 15;
        }
        else
        {
            playerController.moveSpeed = 10;
        }
    }

    void AddPoints()
    {
        
        score += plusPoints;
        scoreUI.text = score.ToString() + " Points";
    }
    void LosePoints()
    {
        
        score -= minuPoints;
        if(score < 0) { score = 0; }
        scoreUI.text = score.ToString() + " Points";
    }
}
