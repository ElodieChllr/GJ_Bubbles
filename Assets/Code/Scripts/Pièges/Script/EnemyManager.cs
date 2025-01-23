using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Pr�fabriqu� de l'ennemi � faire appara�tre
    public List<Transform> spawnPoints = new List<Transform>(); // Liste des points de spawn

    public float spawnInterval = 5f; // Temps entre deux spawns
    public float spawnChance = 0.8f; // Probabilit� qu'un ennemi apparaisse (entre 0 et 1)

    public float elapsedTime = 0f; // Temps �coul� depuis le dernier spawn

    public GameObject pnl_GameOver;
    public ScoreManager scoreManagerRef;

    private void Update()
    {
        // Ajoute le temps �coul�
        elapsedTime += Time.deltaTime;

        // Si l'intervalle est atteint, essaye de faire appara�tre un ennemi
        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f; // R�initialise le temps �coul�

            // V�rifie si un ennemi doit appara�tre (bas� sur la probabilit�)
            if (Random.value <= spawnChance) // Random.value g�n�re un nombre entre 0 et 1
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        // Choisit un point de spawn al�atoire
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Instancie l'ennemi au point de spawn choisi
        Instantiate(enemyPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}
