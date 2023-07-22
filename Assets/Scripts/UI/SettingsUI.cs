using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    public UIManager UIManager;

    public Slider BGMSlider;
    public TextMeshProUGUI BGMVolumeText;
    public Slider SFXSlider;
    public TextMeshProUGUI SFXVolumeText;

    public void CloseButtonClicked()
    {
        UIManager.UIUnfreeze();
        this.gameObject.SetActive(false);
    }

    public void BGMVolumeChanged()
    {
        //SoundManager.Instance.SetBGMVolume(BGMSlider.value);
        BGMVolumeText.text = Mathf.Ceil(BGMSlider.value*100f).ToString();
    }

    public void SFXVolumeChanged()
    {
        //SoundManager.Instance.SetSFXVolume(SFXSlider.value);
        SFXVolumeText.text = Mathf.Ceil(SFXSlider.value * 100f).ToString();
    }
}
