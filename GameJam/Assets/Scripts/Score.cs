using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {
        scoreText.text = "Score: 0";
    }
    
    void Update()
    {
        scoreText.text = FindObjectOfType<Decision>().score.ToString();
    }
}
