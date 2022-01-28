using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool canOpen = false;

    public BlackOut blackOut;
    public string lvlName = "";
    public int lvl =0;

  

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerC = other.gameObject.GetComponent<PlayerController>();
        if (playerC != null)
        {
            if (canOpen)
            {
                AudioManager.instance.PlaySound("doorOpen");
                Animation anim = GetComponent<Animation>();
                anim.Play();
                blackOut.FadeInFadeOut();
                Invoke("ChangeSceen", 0.9f);
                
            }
        }
    }

    void ChangeSceen()
    {
        
        if (lvlName == "")
        {
            if (lvl > GameManager.Instance.getRoomLvl())
                GameManager.Instance.setRoomLvl(lvl);
            GameManager.Instance.loadSceen("Korytarz - Level Select");
        }
        else if (lvlName == "Korytarz - Level Select")
        {
            if (lvl > GameManager.Instance.getRoomLvl())
                GameManager.Instance.setRoomLvl(lvl);
            GameManager.Instance.loadSceen("Korytarz - Level Select");
        }

        else
        {
            GameManager.Instance.loadSceen(lvlName);
        } 
        
        
    }
}
