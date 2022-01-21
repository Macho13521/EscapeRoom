using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorController : MonoBehaviour
{
    [SerializeField]
    private Light[] doorLights;

    [SerializeField]
    private DoorHandler[] doors;

    void Start()
    {

        for (int i=0; i<doorLights.Length; i++)
        {
            doorLights[i].enabled = false;
            doors[i].canOpen = false;
        }
        doorLights[0].enabled = true;
        doors[0].canOpen = true;

        OnRoomLightningUpdate(GameManager.Instance.getRoomLvl());
    }

    void OnRoomLightningUpdate(int room)
    {
        if (room > 0 && room < doorLights.Length)
        {
            doorLights[room].enabled = true;
            doors[room].canOpen = true;
        }
    }
}
