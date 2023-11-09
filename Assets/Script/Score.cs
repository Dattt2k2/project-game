using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text text;
    public AudioSource pointSound;

    private void start()
    {
        score = PlayerPrefs.GetInt("Score");
        text.text = score.ToString();
    }

    public void addScore()
    {
        score++;
        text.text = score.ToString();
        pointSound.Play();
    }

    private void onDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
