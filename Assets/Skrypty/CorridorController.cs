using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorController : MonoBehaviour
{
    [SerializeField]
    private Light[] doorLights;

    

    void Start()
    {
        foreach(var light in doorLights)
        {
            light.enabled = false;
        }
        doorLights[0].enabled = true;

        GameManager.Instance.RoomLigthsUpdate += OnRoomLightningUpdate;
    }

    void OnRoomLightningUpdate(int room)
    {
        if(room>0 && room < doorLights.Length)
            doorLights[room].enabled = true;
    }
}
