using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public int initialDifficulty;
    public int testint;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetDifficulty(int difficulty)
    {
        if (difficulty == 0)
        {
            initialDifficulty = 0;
        }
        else if (difficulty == 1)
        {
            initialDifficulty = 2;
        }
        else if (difficulty == 2)
        {
            initialDifficulty = 4;
        }
        testint = difficulty;
    } 
}
