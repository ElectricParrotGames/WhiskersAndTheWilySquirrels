using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainParamMenu : MonoBehaviour
{
    public GameObject paramMenu;

    public Slider audioSlider;
    public Slider lifeSlider;
    public Toggle particleToggle;

    public TMP_Text textLife;

    void Start()
    {
        audioSlider.SetValueWithoutNotify(GameSetting.SoundVolume);
        lifeSlider.SetValueWithoutNotify(GameSetting.LifeValue);
        particleToggle.SetIsOnWithoutNotify(GameSetting.HasParticule);

        textLife.text = GameSetting.LifeValue.ToString();
    }
    public void OnXClick()
    {
        paramMenu.SetActive(false);
    }

    /// <summary>
    /// function for audio slider use
    /// </summary>
    /// <param name="volume"></param>
    public void AudioSlider(float volume)
    {
        GameSetting.SoundVolume = volume;
    }
    /// <summary>
    /// function for spawn rate slider use
    /// </summary>
    /// <param name="spawnRate"></param>
    public void LifeSlider(float lifeCount)
    {
        GameSetting.LifeValue = lifeCount;
        textLife.text = GameSetting.LifeValue.ToString();
    }
    /// <summary>
    /// function for particle toggle use
    /// </summary>
    /// <param name="toggle"></param>
    public void ParticleToggle(bool toggle)
    {
        GameSetting.HasParticule = toggle;
    }
}
