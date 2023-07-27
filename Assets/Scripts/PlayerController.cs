using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;

    Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed;

    private Vector2 inputMove;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Game.Enable();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputMove = playerInput.Game.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (!GameManager.Instance.IsGamePaused())
        {
            if (inputMove.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            if (inputMove.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            Vector3 moveVector = new Vector3(inputMove.x, inputMove.y, 0f) * moveSpeed * Time.fixedDeltaTime * 100f;

            rb.velocity = moveVector;
        }
    }
}
