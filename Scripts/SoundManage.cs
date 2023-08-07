using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public enum SoundName
    {
        BGM1,
        Collect,
        DropBox,
        Hurt,
        Jump,
        Teleport,
        Win
    }

    [SerializeField] private Sound[] sounds;

    public static SoundManage instance;
    void Start()
    {
        Play(SoundName.BGM1);
    }
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(SoundName name)
    {
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }
        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return Array.Find(sounds, s => s.soundName == name);
    }
}
