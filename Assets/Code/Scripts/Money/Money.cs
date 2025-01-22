using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public PieceManager pieceManagerRef;
    public GameObject obj_money;

    public List<Transform> MoneySpawn = new List<Transform>();
    void Start()
    {
        pieceManagerRef = FindAnyObjectByType<PieceManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pieceManagerRef.AddMoney(1);
            Destroy(gameObject);
        }
    }

    //public void spawnMoney()
    //{
    //    int randomGoodSpawnIndex = Random.Range(0, MoneySpawn.Count);
    //    Transform selectedGoodSpawn = MoneySpawn[randomGoodSpawnIndex];
    //    Instantiate(obj_money, selectedGoodSpawn.position, selectedGoodSpawn.rotation);
    //}
}
