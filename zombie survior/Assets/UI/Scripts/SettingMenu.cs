using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer music;

    public TMP_Dropdown ResDropDown;

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;

        ResDropDown.ClearOptions();

        List<string> options = new List<string>();

        int CurrentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResDropDown.AddOptions(options);
        ResDropDown.value = CurrentResolutionIndex;
        ResDropDown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        music.SetFloat("Volume", volume);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolutie(int resloutionIndex)
    {
        Resolution resolution = resolutions[resloutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
