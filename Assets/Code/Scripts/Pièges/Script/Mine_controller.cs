using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_controller : MonoBehaviour
{
    GameObject pnl_GameOver;
    ScoreManager scoreManagerRef;
    void Start()
    {
        pnl_GameOver = FindAnyObjectByType<EnemyManager>().pnl_GameOver;
        scoreManagerRef = FindAnyObjectByType<EnemyManager>().scoreManagerRef;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touché");
            collision.gameObject.SetActive(false);
            pnl_GameOver.SetActive(true);
            Time.timeScale = 0f;
            scoreManagerRef.GameOver();
        }
    }
}
