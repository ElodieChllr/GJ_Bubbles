using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Rigidbody2D rb_mine;
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2f; 

    private Transform targetPoint; // Point cible actuel

    void Start()
    {
        // Initialisation : l'ennemi commence par se diriger vers le point A
        targetPoint = pointA;
    }

    void Update()
    {
        EnemyMouvement();
    }

    private void EnemyMouvement()
    {
        // Déplacement vers le point cible
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Si l'ennemi atteint le point cible, il change de cible
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = targetPoint == pointA ? pointB : pointA;
            //variable = condition ? valeurSiVrai : valeurSiFaux;
        }
    }
}
