using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    private Score scoreScript;

    private void Awake()
    {
        scoreScript = FindObjectOfType<Score>();
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void Update()
    {
        if (scoreScript.score > PlayerPrefs.GetInt("HighScore"))
        {
            int highScore = scoreScript.score;
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
