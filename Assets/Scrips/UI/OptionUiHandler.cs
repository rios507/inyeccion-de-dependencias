using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionUiHandler : MonoBehaviour
{
    [Inject] AudioManager audioManager;
    [Inject] DisplaySettingsManager displayManager;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider; 

    [SerializeField] Toggle fullscreentoggle;

    [SerializeField] TMP_Dropdown resolutionsDropdown;

    [SerializeField] TMP_Dropdown qualityDropdown;

    public void LoadQualityDropdown()
    {


        qualityDropdown.AddOptions(displayManager.GetQualityNames());

        qualityDropdown.value = displayManager.GetQualityLevel();

        qualityDropdown.onValueChanged.AddListener(delegate
        {
            displayManager.SetQualityLevel(qualityDropdown.value);
        });

    }

    public void LoadResolutionsDropdown()
    {
        List<string> options = new();

        for (int i = 0; i < displayManager.GetResolutions().Length; i++)
        {
            Resolution resolution = displayManager.GetResolutions()[i];
            string format = resolution.width + "X" + resolution.height + "-" + resolution.refreshRateRatio.value.ToString("F0") + "Hz";
            options.Add(format);
        }

        resolutionsDropdown.AddOptions(options);

        resolutionsDropdown.onValueChanged.AddListener(delegate
        {
            displayManager.SetResolution(resolutionsDropdown.value);
        });
    }
    
    void Start()
    {
        LoadResolutionsDropdown();
        LoadFullscreenToggle();
        LoadSlider();
        LoadQualityDropdown();
    }
    public void LoadFullscreenToggle()
    {
        fullscreentoggle.isOn = displayManager.IsFullScreen();

        fullscreentoggle.onValueChanged.AddListener(delegate
        {
            displayManager.SetFullScreen(fullscreentoggle.isOn);
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
