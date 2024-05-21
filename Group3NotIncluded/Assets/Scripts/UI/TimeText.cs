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
        // Managers �ν��Ͻ��� �ʱ�ȭ�� ������ ��ٸ�
        yield return new WaitUntil(() => Managers.Instance != null && Managers.Instance.IsInitialized());

        // Managers �ν��Ͻ� �ʱ�ȭ Ȯ�� �� ����
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
