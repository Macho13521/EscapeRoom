using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider musicSlider, soundSlider;

    private void Start()
    {
        if (musicSlider != null)
            musicSlider.value = AudioManager.instance.masterMusicvolume;

        if (soundSlider != null)
            soundSlider.value = AudioManager.instance.masterSoundvolume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu != null)
            {
                pauseMenu.SetActive(!pauseMenu.activeSelf);
                if (pauseMenu.activeSelf)
                {
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
    }

    public void Resume()
    {
        if (pauseMenu != null)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void onSoundVolumeChange(float soundVolume)
    {
        AudioManager.instance.masterSoundvolume = soundVolume;
    }

    public void onMusicVolumeChange(float musicVolume)
    {
        AudioManager.instance.masterMusicvolume = musicVolume;
    }
}
