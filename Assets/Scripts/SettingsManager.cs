using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsManager : MonoBehaviour
{

    void Start()
    {
        string[] names = QualitySettings.names;
    }

    public void MasterAudioVolume(float volume)
    {
        AudioListener.volume = volume;      
    }

    public void GraphicsQuality(int value)
    {
        QualitySettings.SetQualityLevel(value, true);
    }

}
