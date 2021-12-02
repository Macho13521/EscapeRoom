using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZamekController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    PlayerInputActions playerInputActions;

    private void Start()
    {
        vcam = gameObject.GetComponent<CinemachineVirtualCamera>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Mouse.Enable();
        playerInputActions.Mouse.click.performed += OnClicked;
    }


    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {

            vcam.Priority = 20;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            vcam.Priority = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {

    }

    void OnClicked(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(playerInputActions.Mouse.current.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Clicked on " + hit.transform.name);
        }
        
    }
}
