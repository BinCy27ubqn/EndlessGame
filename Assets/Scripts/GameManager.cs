using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    MainMenu,
    Playing,
    GameOver,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public GameObject gameOverPanel;
    public bool startGame = false;
    public bool isDead = false;

    public float distanceTravel = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        Time.timeScale = 0;
    }

    private void Update()
    {
        distanceTravel = playerController.transform.position.z - gameObject.transform.position.z;
    }

    public void StartGame()
    {
        startGame = true;
        Time.timeScale = 1;
    }
    
    public void PauseGame(int number)
    {
        Time.timeScale = number;
    }

    public void GameOver(PlayerController playerController)
    {
        playerController.playerSpeed = 0f;
        Invoke("DeDead", 0.5f);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void DeDead()
    {
        gameOverPanel.SetActive(true);
    }
}
