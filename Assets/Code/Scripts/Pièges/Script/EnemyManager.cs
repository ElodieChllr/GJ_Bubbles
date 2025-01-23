using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Préfabriqué de l'ennemi à faire apparaître
    public List<Transform> spawnPoints = new List<Transform>(); // Liste des points de spawn

    public float spawnInterval = 5f; // Temps entre deux spawns
    public float spawnChance = 0.8f; // Probabilité qu'un ennemi apparaisse (entre 0 et 1)

    public float elapsedTime = 0f; // Temps écoulé depuis le dernier spawn

    public GameObject pnl_GameOver;
    public ScoreManager scoreManagerRef;

    private void Update()
    {
        // Ajoute le temps écoulé
        elapsedTime += Time.deltaTime;

        // Si l'intervalle est atteint, essaye de faire apparaître un ennemi
        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f; // Réinitialise le temps écoulé

            // Vérifie si un ennemi doit apparaître (basé sur la probabilité)
            if (Random.value <= spawnChance) // Random.value génère un nombre entre 0 et 1
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        // Choisit un point de spawn aléatoire
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform selectedSpawnPoint = spawnPoints[randomIndex];

        // Instancie l'ennemi au point de spawn choisi
        Instantiate(enemyPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }
}
