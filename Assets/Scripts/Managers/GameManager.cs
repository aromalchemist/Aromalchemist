using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    PlayerInput playerInput;

    [SerializeField] private GameObject canvas;

    private bool isPaused;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Game.Enable();
    }

    void Update()
    {
        float inputPause = playerInput.Game.Pause.ReadValue<float>();

        if (inputPause > 0)
        {
            isPaused = !isPaused;
        }

        canvas.SetActive(isPaused);
    }

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }
}
