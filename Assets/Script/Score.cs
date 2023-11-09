using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text text;

    private void start()
    {
        score = PlayerPrefs.GetInt("Score");
        text.text = score.ToString();
    }

    public void addScore()
    {
        score++;
        text.text = score.ToString();
    }

    private void onDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
