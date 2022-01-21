using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool canOpen = false;



    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            if (canOpen)
            {
                GetComponent<Animation>().Play();
                Invoke("ChangeSceen", 0.4f);
            }
        }
    }

    void ChangeSceen()
    {
        int room = GameManager.Instance.getRoomLvl() + 1;
        GameManager.Instance.loadSceen("Room"+ room);
    }
}
