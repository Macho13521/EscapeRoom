using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioHandler : MonoBehaviour
{
    public int soundAmount = 6;

    public SoundEmiter[] soundEmiters;

    public string rightSoundCode;
    public string soundCode;
    public DoorHandler door;

    private void Start()
    {
        GenSoundCode();
        foreach (var soundEmiter in soundEmiters)
        {
            soundEmiter.EmitSoundRadio += EmitedSound;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            if(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.E))
            {
                //AudioManager.instance.PlaySound("sound1");
            }

        }
    }

    private void GenSoundCode()
    {

        List<int> sounds = new List<int>();
        foreach (var soundEmiter in soundEmiters)
        {
            sounds.Add(soundEmiter.soundKey);
        }

        for(int i=0; i< soundAmount; i++)
        {
            rightSoundCode += sounds[Random.Range(0, sounds.Count)];
        }
        Debug.Log("Right SounCode: " + rightSoundCode);
    }

    private void EmitedSound(int soundKey)
    {

        soundCode += soundKey;
        if (soundCode.Length < soundAmount)
        {
            if (rightSoundCode.Substring(0, soundCode.Length) != soundCode)
                soundCode = "";
        }
        else if(soundCode == rightSoundCode)
        {
            door.canOpen = true;
            AudioManager.instance.PlaySound("otwarcieZamka");
        }
    }
}
