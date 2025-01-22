using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_player;
    private Transform t_player;
    public SpriteRenderer sr_player;
    public float horizontalSpeed = 200f;
    public float verticalSpeed = 5f;

    Vector2 moveInput;
    PlayerMap playerMapRef;

    InputAction movementAction;
    InputAction jumpAction;
    public PlayerInput playerInput;



    public GameObject skinOrange;
    public GameObject skinRouge;
    public GameObject skinBleu;
    //public Transform Tr_spawnBackground;
    //public Material backGround;
    //public ScoreManager scoreManagerRef;
    //private float startingHeight;
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        t_player = GetComponent<Transform>();
        playerMapRef = new PlayerMap();



        movementAction = playerInput.actions["Movement"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        PlayerMovement();
        //float distance = t_player.position.y - startingHeight;
    }


    public void PlayerMovement()
    {
        Vector2 movement = movementAction.ReadValue<Vector2>();
        


        if (jumpAction.IsPressed())
        {
            Debug.Log("pouette");
            //rb_player.velocity = new Vector2(rb_player.velocity.x, 50);
        }
        else
        {
            rb_player.velocity = new Vector2(movement.x * horizontalSpeed,0);
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("LastBackGround"))
    //    {
    //        other.GetComponentInParent<BackGroundSpawner>().SpawnNewBackground();            
    //    }
    //    if (other.CompareTag("End_BG"))
    //    {
    //        other.gameObject.SetActive(false);
    //    }
    //}
}
