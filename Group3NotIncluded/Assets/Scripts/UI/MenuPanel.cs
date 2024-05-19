using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private Managers managers;
    private GameObject menuPanel;


    private void Awake()
    {
        managers = Managers.Instance;
    }

    private void Update()
    {
        managers.OnPauseEvent(menuPanel.activeSelf);
    }
}
