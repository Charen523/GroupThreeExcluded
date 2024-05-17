using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    [SerializeField] private BoostSystem boostSystem;
    [SerializeField] private Image fillBar; //�÷��̾��� ������ȭ�� ������ ��, �� �÷��̾ �´� fillBar �ο� �ʿ�.
    
    void Start()
    {
        boostSystem.BoostChangeEvent += (boostAmount) => fillBar.fillAmount = boostAmount;
    }
}
