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
        // �ʱ� ������ �����մϴ�.
        AudioManager.Instance.AdjustVolume(0.2f);

        // �����̴��� ���� �����Ͽ� �ʱ� ������ �°� �����մϴ�.
        slider.value = 0.2f;
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        // �����̴� ���� ����� �� AdjustVolume �޼��带 ȣ���ϵ��� �����մϴ�.
        volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    void HandleSliderValueChanged(float value)
    {
        // �����̴��� ���� �����ɴϴ�.
        float sliderValue = volumeSlider.value;

        // �����̴��� ���� �����Ͽ� �������� �̵��� �� �Ҹ��� �پ�鵵�� �մϴ�.
        float adjustedValue = sliderValue;

        // AudioManager�� AdjustVolume �޼��� ȣ���Ͽ� ���� �����մϴ�.
        AudioManager.Instance.AdjustVolume(adjustedValue);
    }

    void OnSliderValueChanged(float value)
    {
        // �߾��� 0���� �����Ͽ� ���� ��ȯ�մϴ�.
        float centeredValue = (value - 0.5f) * 2f;
    }
}
