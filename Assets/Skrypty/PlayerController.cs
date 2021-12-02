using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed = 5;

    [SerializeField]
    float mouseRotationSpeed = 2;

    [SerializeField]
    float mouseSensitivity = 100f;

    PlayerInputActions playerInputActions;

    public GameObject camera;
    float rotationY = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        Movement();

    }

    private void Update()
    {
        MouseRotation();

    }

    public void Movement()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.velocity = (transform.right * inputVector.x + transform.forward * inputVector.y) * speed;
    }

    public void MouseRotation()
    {
        Vector2 inputVector = playerInputActions.Player.Rotation.ReadValue<Vector2>();


        Vector2 mouse = new Vector2(inputVector.x * mouseSensitivity * Time.deltaTime,
            inputVector.y * mouseSensitivity * Time.deltaTime);


        rotationY -= mouse.y;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        transform.Rotate(Vector3.up * mouse.x);

    }

    


}
