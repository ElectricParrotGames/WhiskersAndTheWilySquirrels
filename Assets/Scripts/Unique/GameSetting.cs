using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    /// <summary>
    /// Save the sound volume to player pref or get it
    /// </summary>
    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 0.5f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }

    /// <summary>
    /// Save the particle boolean to player pref or get it
    /// </summary>
    public static bool HasParticule
    {
        get => PlayerPrefs.GetInt("Particule", defaultValue: 0) >= 1;
        set => PlayerPrefs.SetInt("Particule", value == true ? 1 : 0);
    }

    /// <summary>
    /// Save the lifeValue to player pref or get it
    /// </summary>
    public static float LifeValue
    {
        get => PlayerPrefs.GetFloat("LifeValue", defaultValue: 9);
        set => PlayerPrefs.SetFloat("LifeValue", value);
    }
}
