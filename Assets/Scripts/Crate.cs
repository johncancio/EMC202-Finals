using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public int scoreValue = 10; // Score value of each collected crate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Crate collected!"); // Debug message to ensure collision
            GameManager.instance.AddScore(scoreValue); // Add score to the game manager
            Destroy(gameObject); // Destroy the crate when collided with the player
        }
    }
}
