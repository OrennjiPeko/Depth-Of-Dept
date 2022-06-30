using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    public AudioMixer SFXvolume;
    public AudioMixer BSMvolume;

    public void SFXVolume (float Sound)
    {
        SFXvolume.SetFloat("SFXVolume", Sound);
    }

    public void BSMVolume(float BSM)
    {
        BSMvolume.SetFloat("BSMVolume", BSM);
    }
}
