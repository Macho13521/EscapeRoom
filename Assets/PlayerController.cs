using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed = 5;

    PlayerInputActions playerInputActions;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        
    }


    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.velocity = new Vector3(inputVector.x, 0, inputVector.y) * speed;
    }
}
