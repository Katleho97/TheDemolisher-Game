using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myScore;
    private int scoreNumber;
    
    void Start()
    {
        scoreNumber = 0;
        myScore.text = "SCORE: " + scoreNumber;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("bullet"))
        {
            scoreNumber+=5;
            myScore.text = "SCORE: " + scoreNumber;
        }
    }
}
