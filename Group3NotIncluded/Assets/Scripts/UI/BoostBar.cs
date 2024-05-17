using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    [SerializeField] private BoostSystem boostSystem;
    [SerializeField] private Image fillBar; //플레이어의 프리팹화를 해제한 후, 각 플레이어에 맞는 fillBar 부여 필요.
    
    void Start()
    {
        boostSystem.BoostChangeEvent += (boostAmount) => fillBar.fillAmount = boostAmount;
    }
}
