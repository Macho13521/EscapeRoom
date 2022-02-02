using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    public string rightCode;
    public string Code;
    public int keyPinsAmount = 6;
    private bool playerIsTrigger = false;
    public DoorHandler door;

    public GameObject zamekCanvas;


    public Animation animation;

    private void Start()
    {
        vcam = gameObject.GetComponent<CinemachineVirtualCamera>();
        GenCode();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {

            vcam.Priority = 20;
            Cursor.lockState = CursorLockMode.None;
            if (GameManager.Instance.lockpick)
                playerIsTrigger = true;
            zamekCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            vcam.Priority = 1;
            Cursor.lockState = CursorLockMode.Locked;
            playerIsTrigger = false;
            zamekCanvas.SetActive(false);
        }
    }

    private void GenCode()
    {


        for (int i = 0; i < keyPinsAmount; i++)
        {
            rightCode += Random.Range(0, 2);
        }
        Debug.Log("Right Code: " + rightCode);
    }

    private void Update()
    {
        if (playerIsTrigger)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                ChangelockPin(0);
            if (Input.GetKeyDown(KeyCode.RightArrow))
                ChangelockPin(1);

        }
    }

    private void ChangelockPin(int move)// 0-left, 1-right
    {

        Code += move;
        if (Code.Length < keyPinsAmount)
        {
            if (rightCode.Substring(0, Code.Length) != Code)
            {
                Code = "";
                AudioManager.instance.PlaySound("niew³aœciwazpadka");
            }
            else
            {
                AudioManager.instance.PlaySound("prawid³owazpadka");
            }
        }
        else if (Code == rightCode)
        {
            //door.canOpen = true;
            AudioManager.instance.PlaySound("otwarcieZamka");
            animation.Play();
        }
        else
        {
            Code = "";
            AudioManager.instance.PlaySound("niew³aœciwazpadka");
        }
    }
}
