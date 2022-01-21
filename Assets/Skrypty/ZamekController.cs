using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ZamekController : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    PlayerInputActions playerInputActions;

    public GameObject[] przyciski;
    public GameObject przyciskOk;
    public GameObject przyciskCancel;
    public TextMesh textMesh;
    public int MaxTextLength;

    private int code;
    public DoorHandler door;

    private void Start()
    {
        vcam = gameObject.GetComponent<CinemachineVirtualCamera>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Mouse.Enable();
        playerInputActions.Player.Enable();
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



    void OnClicked(InputAction.CallbackContext context)
    {
        Ray ray = Camera.main.ScreenPointToRay(playerInputActions.Mouse.current.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            foreach (var przycisk in przyciski)
            {
                if (hit.transform.gameObject.Equals(przycisk))
                {
                    if(textMesh.text.Length < MaxTextLength)
                    textMesh.text += hit.transform.name;

                    var buttonAnim = przycisk.GetComponent<ButtonAnimation>();
                    if (buttonAnim != null)
                    {
                        buttonAnim.StartAnimation();
                    }
                }
            }

            if (hit.transform.gameObject.Equals(przyciskOk))
            {
                Debug.Log("Clicked on " + hit.transform.name);
                var buttonAnim = przyciskOk.GetComponent<ButtonAnimation>();
                if (buttonAnim != null)
                {
                    buttonAnim.StartAnimation();
                }
                if (textMesh.text == code.ToString())
                {
                    door.canOpen = true;
                }
            }
            else if (hit.transform.gameObject.Equals(przyciskCancel))
            {
                textMesh.text = string.Empty;
                var buttonAnim = przyciskCancel.GetComponent<ButtonAnimation>();
                if (buttonAnim != null)
                {
                    buttonAnim.StartAnimation();
                }
            }
            
        }
    }

    public void SetCode(int code)
    {
        this.code = code;
    }

}
