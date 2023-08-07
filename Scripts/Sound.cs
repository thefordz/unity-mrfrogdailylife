using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public SoundManage.SoundName soundName;

    public AudioClip clip;
    [Range(0f, 1f)] public float volume; //Range shows a slider in Inspector
    public bool loop;
    [HideInInspector] public AudioSource audioSource;
}
