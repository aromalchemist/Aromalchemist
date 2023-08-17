using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    PlayerInput.GameActions gameInput;

    [SerializeField] private GameObject pausePanel;

    private bool isPaused;

    private void Start()
    {
        gameInput = GameManager.Instance.GetGameInput();
    }

    private void Update()
    {
        float inputPause = gameInput.Pause.ReadValue<float>();

        if (inputPause > 0f && !isPaused)
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausePanel.SetActive(true);
    }

    public void OnClickResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void OnClickGoBackToMainMenu()
    {
        OnClickResumeGame(); // Resetting time scale
        SceneManager.LoadScene("StartMenuScene");
    }
}
