using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionsMenu_UI : UI
{
    public Button openingButton;
    public Button closeButton;

    [Header("SoundEffect Volume")]
    [SerializeField] public Slider soundEffectVolumeSlider;
    public TextMeshProUGUI soundEffectVolumeText;

    [Header("Music Volume")]
    [SerializeField] public Slider musicVolumeSlider;
    public TextMeshProUGUI musicVolumeText;
    void Start()
    {
        InitiateButton(closeButton, ButtonGUIMethod, this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        SetAllVolumes();
    }
    private void OnEnable()
    {
        InitialVolumeSetup();
    }
    private void OnDisable()
    {
        closeButton.image.color = unpressedColor;
        openingButton.image.color = unpressedColor;
    }

    private void InitialVolumeSetup()
    {
        var soundManager = MySoundManager.instance;
        soundEffectVolumeSlider.value = soundManager.soundEffectVolume;
        soundEffectVolumeText.text = Math.Floor(soundManager.soundEffectVolume * 100).ToString();
        musicVolumeSlider.value = soundManager.musicVolume;
        musicVolumeText.text = Math.Floor(soundManager.musicVolume * 100).ToString();

    }
    private void SetAllVolumes()
    {
        SetVolume(soundEffectVolumeText, MySoundManager.instance.ChangeSoundEffectsVolume, soundEffectVolumeSlider.value);
        SetVolume(musicVolumeText, MySoundManager.instance.ChangeMusicVolume, musicVolumeSlider.value);

    }
    private void SetVolume(TextMeshProUGUI text, Action<float> method,float value)
    {
        text.text = Math.Floor(value * 100).ToString();
        method(value);
    }

}
