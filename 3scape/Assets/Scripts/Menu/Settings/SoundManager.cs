using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource music;
    private List<AudioSource> sfx;

    void Update()
    {
        sfx = FindObjectsOfType<AudioSource>().ToList();
        sfx.RemoveAll(x => x == music);

        foreach (var item in sfx)
            item.volume = InputM.sound["Sfx"] * InputM.sound["Master"];

        music.volume = InputM.sound["Music"] * InputM.sound["Master"];
    }
}
