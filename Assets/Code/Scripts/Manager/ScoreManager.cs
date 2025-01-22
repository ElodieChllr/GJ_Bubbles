using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public float verticalSpeed = 10f; 
    public float scoreMultiplier = 0.001f; 

    private float score;


    [Header("HighScore")]
    public TextMeshProUGUI txt_HighScore;
    private static float highScore;
    private string hightScoreKey = "HighScore";

    void Start()
    {
        score = 0;
        int savedHighScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Update()
    {
        score += verticalSpeed * Time.deltaTime * scoreMultiplier;        
    }

    void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat(hightScoreKey, highScore);
            PlayerPrefs.Save();
            UpdateBestScoreText(highScore);
        }

        score = 0;
        UpdateScore();
    }


    void UpdateBestScoreText(float newBestScore)
    {
        txt_HighScore.text = newBestScore.ToString();
    }

    void UpdateScore()
    {
        scoreText.text = $"Score: {score:F2} km";
        txt_HighScore.text = $"HighScore: {highScore:F2} km";
    }

    void Reset_HighScore()
    {
        highScore = 0;
        UpdateBestScoreText(highScore);
    }
}
