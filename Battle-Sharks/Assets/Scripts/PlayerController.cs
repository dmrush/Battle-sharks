using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The Player slider movement
    [Header("Control Settings")]
    [SerializeField] private float maxY = 4.0f; // Maximum Y position
    [SerializeField] private float speed = 5.0f; // Speed of movement
    [SerializeField] private float forwardSpeed = 5.0f; // forward Speed movement

    private float clickedScreenY;
    private float clickedPlayerY;

    void Update()
    {
        HandlePlayerMovement();
        transform.position += new Vector3(forwardSpeed * Time.deltaTime, 0, 0);
    }

    private void HandlePlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenY = Input.mousePosition.y;
            clickedPlayerY = transform.position.y;
        }
        else if (Input.GetMouseButton(0))
        {
            float YDifference = Input.mousePosition.y - clickedScreenY;
            float newYPosition = clickedPlayerY + YDifference * (speed / Screen.height);
            newYPosition = Mathf.Clamp(newYPosition, -maxY, maxY);

            transform.position = new Vector2(transform.position.x, newYPosition);
        }
        else
        {
            // Move player along the x-axis at a constant speed
            
        }
    }
}
