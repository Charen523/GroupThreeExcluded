using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private Managers managers;
    private GameObject pausePanel;


    private void Awake()
    {
        managers = Managers.Instance;
        pausePanel = GetComponent<GameObject>();
    }

    private void OnEnable()
    {
        //Panel�� SetActive�� true�� �� pause.
        managers.OnPauseEvent(true);
    }

    private void OnDisable()
    {
        //Panel�� SetActive�� true�� �� pause.
        managers.OnPauseEvent(false);
    }
}
