using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int hits = 0;
    void UpdateScoreUI()
    {
        scoreText.text = "Hits: " + hits.ToString();
    }

    public void IncremenentHits()
    {
        hits++;
        UpdateScoreUI();
    }
}
