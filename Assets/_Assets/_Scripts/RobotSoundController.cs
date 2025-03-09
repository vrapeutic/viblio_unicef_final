﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSoundController : MonoBehaviour
{
    //vit sounds
    [SerializeField]
    AudioClip[] Level2RobotEnd;
    [SerializeField]
    AudioClip[] Level3RobotIntroandEnd;

    //english sounds
    [SerializeField]
    AudioClip[] Level2RobotEndEng;
    [SerializeField]
    AudioClip[] Level3RobotIntroandEndEng;
    // Start is called before the first frame update
    AudioSource speaker;

    [SerializeField] BoolValue isVit;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }

    public void PlayLevel2Sound(int id)
    {
        if (speaker.isPlaying) return;
        if (isVit.Value) speaker.clip = Level2RobotEnd[id];
        else speaker.clip = Level2RobotEndEng[id];
        speaker.Play();
    }

    public void PlayLevel3Sound(int id)
    {
        if (speaker.isPlaying) return;
        if(isVit.Value) speaker.clip = Level3RobotIntroandEnd[id];
        else speaker.clip = Level3RobotIntroandEndEng[id];
        speaker.Play();
    }

    public void StopSound()
    {
        speaker.Stop();
        speaker.clip= null;
    }

}
