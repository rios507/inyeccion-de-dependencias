using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DisplaySettingsManager : MonoBehaviour
{
    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public Resolution[] GetResolutions()
    {
        return Screen.resolutions;
    }
    public List<string> GetQualityNames()
    {
        return QualitySettings.names.ToList();
    }
    public void SetQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public int GetQualityLevel()
    {
        return QualitySettings.GetQualityLevel();
    }
    public bool IsFullScreen()
    {
        return Screen.fullScreen;
    }
}

