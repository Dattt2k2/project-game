using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Score>().addScore();
    }
}
