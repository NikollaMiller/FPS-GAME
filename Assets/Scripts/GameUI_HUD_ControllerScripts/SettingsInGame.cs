using UnityEngine;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    [SerializeField] private _playerMousecontroller _sensa;
    [SerializeField] private Slider[] _sliderSetting;
    [SerializeField] private Camera _fieldSetting;
    //[SerializeField] private AudioSource Muisc;
    //[SerializeField] private AudioSource Sound;

    private void Start()
    {
        for (int i = 0; i < _sliderSetting.Length; i++)
        {
            _sliderSetting[i].value = PlayerPrefs.GetFloat($"Slider{i}");
        }
    }

    private void Update()
    {
        //Muisc.volume = _sliderSetting[0].value;

        //Sound.volume = _sliderSetting[1].value;

        _sensa._MouseSensitivity = _sliderSetting[2].value;

        _fieldSetting.fieldOfView = _sliderSetting[3].value;

        _fieldSetting.farClipPlane = _sliderSetting[4].value;
        
        for (int i = 0; i < _sliderSetting.Length; i++)
        {
            PlayerPrefs.SetFloat($"Slider{i}", _sliderSetting[i].value);
        }

    }

}
