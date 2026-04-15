using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>(); // Gets current value of MoveAction
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 0.01f; // Moves in direction according to move action
        transform.position = position;
    }
}
