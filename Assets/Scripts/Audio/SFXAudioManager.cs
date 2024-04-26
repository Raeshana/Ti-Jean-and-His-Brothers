using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    [Header("------------Audio Sources-----------")]
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clips-----------")]
    public AudioClip chop;
    public AudioClip collect;
    public AudioClip typing;
    public AudioClip button;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
