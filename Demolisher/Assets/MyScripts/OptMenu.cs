using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resDropdown;

    void Start ()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> opt = new List<string>();
        int currentResolutionI = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string opts = resolutions[i].width + " x " + resolutions[i].height;
            opt.Add(opts);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionI = i;
            }
        }
        resDropdown.AddOptions(opt);
        resDropdown.value = currentResolutionI;
        resDropdown.RefreshShownValue();
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("volume", vol);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool fullScreenIndex)
    {
        Screen.fullScreen = fullScreenIndex;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
