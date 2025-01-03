using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonAudio : MonoBehaviour
{
    private SFXAudioManager audioManager;
    
    void Start() {
        audioManager = GetComponent<SFXAudioManager>();
    }

    public void PlayAudio()
    {
        audioManager.PlaySFX(audioManager.button); // Play chop audio
    }
}
