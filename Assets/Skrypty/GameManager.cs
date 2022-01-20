using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public Action<int> RoomLigthsUpdate;

    private int room;

    private void Awake()
    {
        if (_instance == null )
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Init()
    {
        this.room = 0;
        setRoomLvl(this.room);
        
    }

    public void setRoomLvl(int room)
    {
        this.room = room;
        RoomLigthsUpdate?.Invoke(this.room);
    }

    public void loadSceen(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void exitGame()
    {
        Application.Quit();
    }

    

}
