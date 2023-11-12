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


        Pref.Coins += 1;
        PlayerPrefs.SetInt("Coins", Pref.Coins);

        Debug.Log(Pref.Coins);
    }

    private void onDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
