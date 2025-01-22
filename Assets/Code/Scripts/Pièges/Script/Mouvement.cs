using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    public Rigidbody2D rb_mine;
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        //Initialisation: l'ennemi commence par se diriger vers le pt A
        targetPoint = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMouvement();
    }
    private void EnemyMouvement()
    {
        //Déplacement ver le point cible
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        //Si l'ennemi atteint le pt cible alors il change de cible
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint=targetPoint==pointA? pointB : pointA;
            //variable = condition? valeur Si Vrai:valeur Si Faux
        }
    }
}
