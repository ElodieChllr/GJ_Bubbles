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

    public static float money;
    private float lastYPosition;
    //private float score;
    PieceManager pieceManagerRef;

    [HideInInspector]public GameObject skinOrange;
    [HideInInspector]public GameObject skinRouge;
    [HideInInspector]public GameObject skinBleu;

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
        float currentY = transform.position.y;
        if (Mathf.Abs(currentY - lastYPosition) >= 5f)
        {
            pieceManagerRef.SpawnPieces();
            lastYPosition = currentY;
        }
    }


    public void PlayerMovement()
    {
        Vector2 movement = movementAction.ReadValue<Vector2>();
        


        if (jumpAction.IsPressed())
        {
            Debug.Log("pouette");
        }
        else
        {
            rb_player.velocity = new Vector2(movement.x * horizontalSpeed,0);
        }
    }
}
