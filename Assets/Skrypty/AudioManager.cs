using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] musics;

    public bool loopMusic = false;

    [Range(0f, 1f)]
    public float masterSoundvolume;
    [Range(0f, 1f)]
    public float masterMusicvolume;

    private AudioSource musicSource;
    private int musicIndex;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (musics.Length > 0)
            PlayMusic();
    }

    private void PlayMusic()
    {
        if (musicIndex < musics.Length)
        {
            musicSource.clip = musics[musicIndex].clip;
            musicSource.volume = musics[musicIndex].volume * masterMusicvolume;
            musicSource.Play();
            Invoke("PlayMusic", musics[musicIndex].clip.length + 0.1f);
        }

        musicIndex++;

        if (loopMusic)
            if (musicIndex == musics.Length)
                musicIndex = 0;

        
    }


    public void PlaySound(string name)
    {
        Sound found = null;
        foreach (Sound s in sounds)
        {
            if(s.name == name)
                found = s;
        }
        if(found != null)
        {
            GameObject sound = new GameObject("Sound: " + found.name);
            sound.transform.parent = transform;
            sound.AddComponent<AudioSource>();
            AudioSource audioSource = sound.GetComponent<AudioSource>();
            audioSource.clip = found.clip;
            audioSource.volume = found.volume * masterSoundvolume;
            audioSource.Play();
            Destroy(sound, audioSource.clip.length + 0.1f);
        }
        else
        {
            Debug.LogWarning("Sound: " + name + " not found!!!!!");
        }
    }

    public void onSoundVolumeChange(float soundVolume)
    {
        masterSoundvolume = soundVolume;
    }

    public void onMusicVolumeChange(float musicVolume)
    {
        masterMusicvolume = musicVolume;
    }
}
