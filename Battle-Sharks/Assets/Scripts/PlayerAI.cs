using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [Header("Control Settings")]
    [SerializeField] private float maxY = 4.0f; 
    [SerializeField] private float speed = 5.0f; 

    private float clickedScreenY;
    private float clickedPlayerY;
    public float ForwardMoveSpeed = 0.1f;
   
    private void Start() { }

    void Update()
    {
        HandlePlayerMovement();
        transform.position += new Vector3(ForwardMoveSpeed, 0, 0);
        
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
    }

    
}
