using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager
        gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stepped on mine!"); // Debug message to ensure collision

            // Trigger game over
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
