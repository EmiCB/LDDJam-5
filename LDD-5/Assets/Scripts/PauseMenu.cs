using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject gameWonMenu;

    public PlayerController player;
    public Timer timer;
    public LevelEnd levelEnd;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) Resume();
            else Pause();
        }

        // end game when timer hits 0
        if (timer.timeRemaining == 0 && !gameOverMenu.activeSelf) GameOver();

        if (levelEnd.HasWon() && !gameWonMenu.activeSelf) GameWon();
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void MainMenu() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        Application.Quit();
    }

    void GameOver() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void GameWon() {
        gameWonMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Retry() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
