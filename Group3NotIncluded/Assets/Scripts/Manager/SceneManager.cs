using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneManager : MonoBehaviour
{

    [Header("PanelList")]
    public GameObject menuPanel;
    public GameObject rankPanel;

    [Header("SoloRank")]
    public TextMeshProUGUI[] soloName;
    public TextMeshProUGUI[] soloTime;

    [Header("CoopRank")]
    public TextMeshProUGUI[] CoopName;
    public TextMeshProUGUI[] CoopTime;

    private void Awake()
    {
        
    }


    public void LoadSoloMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SoloScene");
    }

    public void LoadCoopMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CoopScene");
    }

    public void LoadVersusMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("VersusScene");
    }

}
