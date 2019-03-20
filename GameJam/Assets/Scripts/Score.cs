using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;

    Decision m_decision;

    void Start()
    {
        scoreText.text = "Score: 0";
    }
    
    void Update()
    {
        scoreText.text = Decision.score.ToString();
    }


}
