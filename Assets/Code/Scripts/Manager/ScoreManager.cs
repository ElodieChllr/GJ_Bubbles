using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI txt_ScoreInGame; 
    public TextMeshProUGUI txt_scorePause;
    public TextMeshProUGUI txt_scoreGO;

    public float verticalSpeed = 10f; 
    public float scoreMultiplier = 0.001f; 

    public float score;


    [Header("HighScore")]
    public TextMeshProUGUI txt_HighScore;
    public TextMeshProUGUI txt_HighScoreGO;
    private static float highScore;
    private string hightScoreKey = "HighScore";

    void Start()
    {
        Time.timeScale = 1f;
        //score = 0;
        Debug.Log(highScore);
        UpdateBestScoreText(highScore);
    }

    void Update()
    {
        score += verticalSpeed * Time.deltaTime * scoreMultiplier;

        
        UpdateScore();
    }

    public void GameOver()
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
       // txt_HighScore.text = newBestScore.ToString();
        txt_HighScore.text = $"{highScore:F2}";
        txt_HighScoreGO.text = $"{highScore:F2}";
    }

    void UpdateScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        txt_ScoreInGame.text = $" {score:F2}";
        txt_HighScore.text = $"{highScore:F2}";
        txt_scoreGO.text = $" {score:F2}";
        txt_HighScoreGO.text = $"{highScore:F2}";
    }

    public void Reset_HighScore()
    {
        highScore = 0;
        UpdateBestScoreText(highScore);
    }
}
