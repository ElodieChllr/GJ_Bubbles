using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb_player;
    public float horizontalSpeed = 200f;
    private float verticalSpeed = 1f;

    Vector2 moveInput;
    PlayerMap playerMapRef;

    InputAction movementAction;
    public PlayerInput playerInput;
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        playerMapRef = new PlayerMap();



        movementAction = playerInput.actions["Movement"];
    }

    void Update()
    {
        PlayerMovement();
    }


    public void PlayerMovement()
    {
        Vector2 movement = movementAction.ReadValue<Vector2>();
        rb_player.velocity = new Vector2(movement.x * horizontalSpeed, verticalSpeed);
    }
}
