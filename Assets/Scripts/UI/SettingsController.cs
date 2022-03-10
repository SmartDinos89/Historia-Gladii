using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer; 
    public void setVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void Quit(){
        SceneManager.LoadScene(0);
    }
}
