using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionUiHandler : MonoBehaviour
{
    [Inject] AudioManager audioManager;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider; 

    [SerializeField] Toggle fullscreentoggle;

    [SerializeField] TMP_Dropdown resolutionsDropdown;

    public void LoadResolutionsDropdown()
    {
        List<string> options = new();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Resolution resolution = Screen.resolutions[i];
            string format = resolution.width + "X" + resolution.height + "-" + resolution.refreshRateRatio.value.ToString("F0") + "Hz";
            options.Add(format);
        }

        resolutionsDropdown.AddOptions(options);

        resolutionsDropdown.onValueChanged.AddListener(delegate
        {

        });
    }
    
    void Start()
    {
        LoadResolutionsDropdown();
        LoadFullscreenToggle();
        LoadSlider();
    }
    public void LoadFullscreenToggle()
    {
        fullscreentoggle.onValueChanged.AddListener(delegate
        {
            Screen.fullScreen = fullscreentoggle.isOn;
        });
    }
    public void LoadSlider()
    {
        masterSlider.value = audioManager.MasterVolume;

        masterSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetMasterVolume(masterSlider.value);
        });

        musicSlider.value = audioManager.MusicVolume;

        musicSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetMusicVolume(musicSlider.value);
        });


        sfxSlider.value = audioManager.SfxVolume;


        sfxSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetSfxVolume(sfxSlider.value);
        });
    }
    
   
}
