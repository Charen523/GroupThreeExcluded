using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    private Managers managers;
    public GameObject endPanel;

    private void Awake()
    {
        managers = Managers.Instance;
    }

    private void OnEnable()
    {
        if (managers != null)
        {
            managers.OnGameOver += ShowEndPanel;
        }
    }

    private void OnDisable()
    {
        if (managers != null)
        {
            managers.OnGameOver -= ShowEndPanel;
        }
    }

    private void ShowEndPanel()
    {
        endPanel.SetActive(true);
    }
}
