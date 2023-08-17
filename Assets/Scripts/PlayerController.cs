using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput.GameActions gameInput;

    Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed;

    private Vector2 inputMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gameInput = GameManager.Instance.GetGameInput();
    }

    private void Update()
    {
        inputMove = gameInput.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
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
