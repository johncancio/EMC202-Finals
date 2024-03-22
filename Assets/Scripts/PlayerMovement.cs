using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f; // Adjust this value to control the movement speed
    public float smoothTime = 0.1f;
    private float angleVelocity;

    public Animator animator; // Reference to the Animator component

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on player input
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If the movement direction is not zero, move the character
        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref angleVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveVector = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveVector.normalized * moveSpeed * Time.deltaTime);

            // Set the "isRunning" parameter in the Animator to true
            animator.SetBool("isRunning", true);
        }
        else
        {
            // Set the "isRunning" parameter in the Animator to false
            animator.SetBool("isRunning", false);
        }
    }
}
