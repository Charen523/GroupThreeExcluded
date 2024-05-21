using System.Collections;
using UnityEngine;

public class CreditPanel : MonoBehaviour
{
    public float displayDuration = 5f; // readonly�� �����ϰ�, �ν����Ϳ��� ���� �����ϵ��� ����

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowCredits()
    {
        gameObject.SetActive(true);
        StartCoroutine(CreditDelay());
    }

    private IEnumerator CreditDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        gameObject.SetActive(false);
    }
}
