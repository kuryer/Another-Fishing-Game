using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [Header("SFX")]
    [SerializeField] SavedFloat sfxVolume;
    [SerializeField] Slider sfxVolumeSlider;

    [Header("Music")]
    [SerializeField] SavedFloat musicVolume;
    [SerializeField] Slider musicVolumeSlider;

    private void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        sfxVolume.Initialize();
        musicVolume.Initialize();

        audioMixer.SetFloat(sfxVolume.VariableName, sfxVolume.Value);
        audioMixer.SetFloat(musicVolume.VariableName, musicVolume.Value);

        sfxVolumeSlider.value = sfxVolume.Value;
        musicVolumeSlider.value = musicVolume.Value;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfxVolume.SetValue(volume);
        audioMixer.SetFloat(sfxVolume.VariableName, sfxVolume.Value);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume.SetValue(volume);
        audioMixer.SetFloat(musicVolume.VariableName, musicVolume.Value);
    }
}
