using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0; 

   
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncrementScore()
    {
        score++; 
        UpdateScoreUI(); 
    }
}

