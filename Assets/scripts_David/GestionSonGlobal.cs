using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider sliderSon;
    [SerializeField] AudioMixer masterMixer;

    private void Start()
    {
        MettreVolume(PlayerPrefs.GetFloat("VolumeJoueur", 100));
    }

    public void MettreVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("VolumeJoueur", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void ChangerVolumeSlider()
    {
        MettreVolume(sliderSon.value);
    }

    public void RefreshSlider(float _value)
    {
        sliderSon.value = _value;
    }
}