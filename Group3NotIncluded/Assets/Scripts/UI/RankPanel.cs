using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : MonoBehaviour
{
    private Managers managers;
    private GameObject rankPanel;


    private void Awake()
    {
        managers = Managers.Instance;
    }

    private void Update()
    {
        managers.OnPauseEvent(rankPanel.activeSelf);
    }
}
