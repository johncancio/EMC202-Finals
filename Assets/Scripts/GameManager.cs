using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance of the GameManager
    private int score = 0; // Current score
    private bool gameStarted = false; // Flag to track whether the game has started
    public GameObject playButton;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshPro Text component displaying the score
    public TextMeshProUGUI gameOverText; //Reference to Game Over text

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Set timescale to 0 to pause the game initially
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            Debug.Log("Game started!");
            // Put your game initialization code here
            gameStarted = true;

            // Set timescale to normal to start the game
            Time.timeScale = 1f;

            // Deactivate or hide the play button
            playButton.SetActive(false);
        }
        else
        {
            Debug.Log("Game is already started!");
        }
    }

    //GameOver Scenario
    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Show the "Game Over" text
        gameOverText.gameObject.SetActive(true);

        // Set timescale to 0 to pause the game
        Time.timeScale = 0f;
    }

    public void AddScore(int value)
    {
        if (gameStarted)
        {
            score += value;
            Debug.Log("Score: " + score); // Log the updated score

            // Update the score text
            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
            else
            {
                Debug.LogWarning("Score Text is not assigned!");
            }
        }
        else
        {
            Debug.Log("Cannot add score: Game not started!");
        }
    }
}
