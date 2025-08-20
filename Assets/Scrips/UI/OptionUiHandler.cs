using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OptionUiHandler : BaseUIPanel
{
    [Inject] UIManager uiManager;
    [Inject] AudioManager audioManager;
    [Inject] DisplaySettingsManager displayManager;

    [SerializeField] Button backButtom;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider; 

    [SerializeField] Toggle fullscreentoggle;

    [SerializeField] TMP_Dropdown resolutionsDropdown;

    [SerializeField] TMP_Dropdown qualityDropdown;

    public override void Show()
    {
        base.Show();

        fullscreentoggle.isOn = displayManager.IsFullScreen();
        qualityDropdown.value = displayManager.GetQualityLevel();
        sfxSlider.value = audioManager.SfxVolume;
        masterSlider.value = audioManager.MasterVolume;
        musicSlider.value = audioManager.MusicVolume;
    }
    public void LoadQualityDropdown()
    {


        qualityDropdown.AddOptions(displayManager.GetQualityNames());



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
    
    public override void Initialize()
    {
        backButtom.onClick.AddListener(delegate
        {
            uiManager.ShowPanel(UIPanelEnum.MainMenu);
        });
        base.Initialize();
        LoadResolutionsDropdown();
        LoadFullscreenToggle();
        LoadSlider();
        LoadQualityDropdown();
    }
    public void LoadFullscreenToggle()
    {


        fullscreentoggle.onValueChanged.AddListener(delegate
        {
            displayManager.SetFullScreen(fullscreentoggle.isOn);
        });
    }
    public void LoadSlider()
    {


        masterSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetMasterVolume(masterSlider.value);
        });



        musicSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetMusicVolume(musicSlider.value);
        });





        sfxSlider.onValueChanged.AddListener(delegate
        {
            audioManager.SetSfxVolume(sfxSlider.value);
        });
    }
    
   
}
