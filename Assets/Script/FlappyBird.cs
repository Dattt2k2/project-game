using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBird : MonoBehaviour
{

    Rigidbody2D rg;

    public GameObject gameOverOjb;

    public float speed;

    private void Start()
    {
        Time.timeScale = 1;
        rg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(Vector2.up * speed);
        }
    }

    public void resetGame()
    {
        SceneManager.LoadScene(0);
    }

    void GameOver()
    {
        gameOverOjb.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    
}
