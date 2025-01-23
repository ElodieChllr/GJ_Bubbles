using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieceManager : MonoBehaviour
{
    public TextMeshProUGUI txt_money; // Texte pour afficher l'argent
    private static int money;

    public GameObject GO_Money; // Pr�fabriqu� pour les pi�ces
    public List<Transform> PiecesSpawn = new List<Transform>(); // Liste des points de spawn

    public float spawnInterval = 5f; // Intervalle de spawn en secondes
    public float spawnChance = 0.5f; // Probabilit� qu'une pi�ce apparaisse � chaque intervalle (entre 0 et 1)

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0.0f; // Initialise le temps �coul�
        UpdateMoney(); // Affiche l'argent au d�part
    }

    private void Update()
    {
        // Ajoute le temps �coul�
        elapsedTime += Time.deltaTime;

        // V�rifie si le temps d'apparition est �coul�
        if (elapsedTime >= spawnInterval)
        {
            elapsedTime = 0f; // R�initialise le temps �coul�

            // V�rifie si une pi�ce doit appara�tre en fonction de la probabilit�
            if (Random.value <= spawnChance) // Random.value g�n�re un nombre entre 0 et 1
            {
                SpawnPieces(); // Fais appara�tre une pi�ce
            }
        }
    }

    public void UpdateMoney()
    {
        txt_money.text = money.ToString(); // Met � jour le texte de l'argent

        PlayerPrefs.SetInt("Pieces", money); // Enregistre le nombre de pi�ces
        PlayerPrefs.Save();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd; // Ajoute l'argent
        UpdateMoney(); // Met � jour l'affichage
    }

    public void SpawnPieces()
    {
        // Choisis un point de spawn al�atoire
        int randomGoodSpawnIndex = Random.Range(0, PiecesSpawn.Count);
        Transform selectedGoodSpawn = PiecesSpawn[randomGoodSpawnIndex];

        // Instancie une pi�ce au point de spawn choisi
        Instantiate(GO_Money, selectedGoodSpawn.position, selectedGoodSpawn.rotation);
    }

    public void GameOverMoney()
    {
        money = 0; // R�initialise l'argent
        UpdateMoney(); // Met � jour l'affichage
    }

}
