using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieceManager : MonoBehaviour
{
    public TextMeshProUGUI txt_money;
    private static int money;

    public GameObject GO_Money;
    public float elapsedTime;


    //public Transform spawnPointPiece;

    public List<Transform> PiecesSpawn = new List<Transform>();

    public PlayerController playerControllerRef;



    private void Start()
    {
        //elapsedTime = 0.0f;
    }
    private void Update()
    {
        
    }

    public void UpdateMoney()
    {
        txt_money.text = money.ToString();

        PlayerPrefs.SetInt("Pieces", +money);//Enregistre le nombre de pieces
        PlayerPrefs.Save();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        UpdateMoney();
    }

    public void SpawnPieces()
    {
        int randomGoodSpawnIndex = Random.Range(0, PiecesSpawn.Count);
        Transform selectedGoodSpawn = PiecesSpawn[randomGoodSpawnIndex];
        Instantiate(GO_Money, selectedGoodSpawn.position, selectedGoodSpawn.rotation);
    }


    public void GameOverMoney()
    {
        money = 0;

    }

}
