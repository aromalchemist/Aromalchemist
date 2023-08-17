using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Game.Enable();
    }

    private void OnDisable()
    {
        playerInput.Game.Disable();
    }

    public PlayerInput.GameActions GetGameInput()
    {
        return playerInput.Game;
    }
}
