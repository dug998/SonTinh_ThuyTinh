using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : PopupBase
{

    [Header(" --- Sound --- ")]

    public Slider _sliderSound;
    public TextMeshProUGUI _txtVolumeSound;
    [Header(" --- Music --- ")]

    public Slider _sliderMusic;
    public TextMeshProUGUI _txtVolumeMusic;
    [Header("--- Vibrate ---")]

    public Button btnVibrate;
    public GameObject VibrateOn, VibrateOff;

    [Header("Gift code")]
    public InputField _inputField;
    public GameObject _objGiftCode;





    public void CheckGirtCode()
    {
        _objGiftCode.SetActive(_inputField.text.Contains("dungdz"));

        _inputField.text = "";

    }
    public void Start()
    {
        btnVibrate.onClick.AddListener(ClickVibrate);
        _sliderSound.onValueChanged.AddListener(OnValuesChangedSound);
        _sliderMusic.onValueChanged.AddListener(OnValuesChangedMusic);
        CheckAudio();
    }

    public void ClickVibrate()
    {
        UserData.turnOffVibrate = !UserData.turnOffVibrate;

        CheckActiveVibrate();
    }

    public void OnValuesChangedSound(float values)
    {
        UserData.turnVolumeSound = values;
        _txtVolumeSound.text = values * 10 + "";
        CheckActiveSound();
    }
    public void OnValuesChangedMusic(float values)
    {
        UserData.turnVolumeMusic = values;

        _txtVolumeMusic.text = values * 10 + "";
        CheckActiveSound();
    }
    public void CheckAudio()
    {
        CheckActiveSound();
        CheckActiveVibrate();
    }

    void CheckActiveSound()
    {
        SoundManager.Instance.UpdateMute();
    }

    void CheckActiveVibrate()
    {
        SoundManager.Instance.UpdateMute();
        VibrateOn.SetActive(UserData.turnOffVibrate);
        VibrateOff.SetActive(!UserData.turnOffVibrate);
    }
}
