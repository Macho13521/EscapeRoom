using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmiter : MonoBehaviour
{

    public int soundKey = 0;

    public Action<int> EmitSoundRadio;

    private void OnTriggerStay(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Sound: " + soundKey);
                EmitSound();
            }

        }
    }

    private void EmitSound()
    {
        EmitSoundRadio?.Invoke(soundKey);
        //AudioManager.instance.PlaySound("sound1");

    }
}
