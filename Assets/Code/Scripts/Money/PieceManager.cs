using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieceManager : MonoBehaviour
{
    public TextMeshProUGUI txt_money; // Texte pour afficher l'argent
    private static int money;

    public GameObject GO_Money; // Préfabriqué pour les pièces
    public List<Transform> PiecesSpawn = new List<Transform>(); // Liste des points de spawn

    public float spawnInterval = 5f; // Intervalle de spawn en secondes
    public float spawnChance = 0.5f; // Probabilité qu'une pièce apparaisse à chaque intervalle (entre 0 et 1)

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0.0f; // Initialise le temps écoulé
        UpdateMoney(); // Affiche l'argent au départ
    }

    private void Update()
    {
        // Ajoute le temps écoulé
        elapsedTime += Time.deltaTime;

        // Vérifie si le temps d'apparition est écoulé
        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f; // Réinitialise le temps écoulé

            // Vérifie si une pièce doit apparaître en fonction de la probabilité
            if (Random.value <= spawnChance) // Random.value génère un nombre entre 0 et 1
            {
                SpawnPieces(); // Fais apparaître une pièce
            }
        }
    }

    public void UpdateMoney()
    {
        txt_money.text = money.ToString(); // Met à jour le texte de l'argent

        PlayerPrefs.SetInt("Pieces", money); // Enregistre le nombre de pièces
        PlayerPrefs.Save();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd; // Ajoute l'argent
        UpdateMoney(); // Met à jour l'affichage
    }

    public void SpawnPieces()
    {
        // Choisis un point de spawn aléatoire
        int randomGoodSpawnIndex = Random.Range(0, PiecesSpawn.Count);
        Transform selectedGoodSpawn = PiecesSpawn[randomGoodSpawnIndex];

        // Instancie une pièce au point de spawn choisi
        Instantiate(GO_Money, selectedGoodSpawn.position, selectedGoodSpawn.rotation);
    }

    public void GameOverMoney()
    {
        money = 0; // Réinitialise l'argent
        UpdateMoney(); // Met à jour l'affichage
    }

}
