using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player; 
    public TextMeshProUGUI scoreText; 
    public float scoreMultiplier = 0.001f; 

    private float startingHeight; 
    private float score;

    void Start()
    {
        startingHeight = player.position.y;
        score = 0;
    }

    void Update()
    {
        float distance = player.position.y - startingHeight;

        if (distance > 0)
        {
            score = distance * scoreMultiplier;
        }

        scoreText.text = $"Score: {score:F2}";
    }
}
