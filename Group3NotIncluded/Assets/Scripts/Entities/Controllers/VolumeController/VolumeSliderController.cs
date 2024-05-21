using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VolumeSliderController : MonoBehaviour
{
    public UnityEngine.UI.Slider slider;
    public UnityEngine.UI.Slider volumeSlider;

    void Start()
    {
        // 초기 볼륨을 설정합니다.
        AudioManager.Instance.AdjustVolume(0.2f);

        // 슬라이더의 값을 조정하여 초기 볼륨에 맞게 설정합니다.
        slider.value = 0.2f;
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        // 슬라이더 값이 변경될 때 AdjustVolume 메서드를 호출하도록 설정합니다.
        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    void HandleSliderValueChanged(float value)
    {
        // 슬라이더의 값을 가져옵니다.
        float sliderValue = volumeSlider.value;

        // 슬라이더의 값을 조절하여 왼쪽으로 이동할 때 소리가 줄어들도록 합니다.
        float adjustedValue = sliderValue;

        // AudioManager의 AdjustVolume 메서드 호출하여 볼륨 조절합니다.
        AudioManager.Instance.AdjustVolume(adjustedValue);
    }

    void OnSliderValueChanged(float value)
    {
        // 중앙을 0으로 설정하여 값을 변환합니다.
        float centeredValue = (value - 0.5f) * 2f;
    }
}
