using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("Volume", AudioManager.Instance.volume);
        slider.onValueChanged.AddListener(AudioManager.Instance.SetVolume);
    }
}
