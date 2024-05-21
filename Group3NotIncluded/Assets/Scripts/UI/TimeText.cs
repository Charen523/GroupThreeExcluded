using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    private Managers managers;
    public TextMeshProUGUI timeTxt;

    private bool isPaused;

    private void Awake()
    {
        isPaused = false;
    }

    private IEnumerator Start()
    {
        // Managers 인스턴스가 초기화될 때까지 기다림
        yield return new WaitUntil(() => Managers.Instance != null && Managers.Instance.IsInitialized());

        // Managers 인스턴스 초기화 확인 후 설정
        managers = Managers.Instance;

        managers.OnPause += (pause) => isPaused = pause;
    }

    private void Update()
    {
        UpdateTimeText(isPaused);
    }

    private void UpdateTimeText(bool pause)
    {
        if (managers == null) return;
        if (!pause)
        {
            timeTxt.text = (managers.gameManager.GetTime().ToString("N2"));
        }
    }
}
