using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider _soundsAudioSlider;
    [SerializeField] private Slider _musicAudioSlider;

    [SerializeField] private AudioSource _soundAudioSource;
    [SerializeField] private AudioSource _musicAudioSource;

    private void OnEnable()
    {
        _soundAudioSource.volume = SettingsManager.soundVolume;
        _musicAudioSource.volume = SettingsManager.musicVolume;

        _soundsAudioSlider.value = SettingsManager.soundVolume;
        _musicAudioSlider.value = SettingsManager.musicVolume;
    }

    public void ChangeVolume()
    {
        _soundAudioSource.volume = _soundsAudioSlider.value;
        _musicAudioSource.volume = _musicAudioSlider.value;
    }

    public void ConfirmSettings()
    {
        SettingsManager.soundVolume = _soundsAudioSlider.value;
        SettingsManager.musicVolume = _musicAudioSlider.value;
    }
}
