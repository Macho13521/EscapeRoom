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

    private bool isTrigger = false;

    private void Start()
    {
        GenSoundCode();
        foreach (var soundEmiter in soundEmiters)
        {
            soundEmiter.EmitSoundRadio += EmitedSound;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            isTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StopAllCoroutines();
                StartCoroutine(MytserySounds());
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

    IEnumerator MytserySounds()
    {
        for (int i = 0; i < soundAmount; i++) {
            int x = int.Parse(rightSoundCode[i].ToString());
            soundEmiters[x].PlaySound();
            yield return new WaitForSeconds(2);

        }
    }
}
