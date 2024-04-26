using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAudio : MonoBehaviour
{
    [SerializeField] SFXAudioManager audioManager;
    
    public void PlayAudio()
    {
        audioManager.PlaySFX(audioManager.button); // Play chop audio
    }
}
