using System.Collections;
using UnityEngine;

public class CreditPanel : MonoBehaviour
{
    public float displayDuration = 5f; // readonly를 제거하고, 인스펙터에서 설정 가능하도록 수정

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
