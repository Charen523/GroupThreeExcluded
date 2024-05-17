using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenManager : MonoBehaviour
{
    //��ġ UI ��ũ��Ʈ �����ιٲ�� ��.
    [Header("PanelList")]
    public GameObject menuPanel;
    public GameObject rankPanel;

    [Header("SoloRank")]
    public TextMeshProUGUI[] soloName;
    public TextMeshProUGUI[] soloTime;

    [Header("CoopRank")]
    public TextMeshProUGUI[] CoopName;
    public TextMeshProUGUI[] CoopTime;

    public void LoadSoloMode()
    {
        SceneManager.LoadScene("SoloScene");
    }

    public void LoadCoopMode()
    {
        SceneManager.LoadScene("CoopScene");
    }

    public void LoadVersusMode()
    {
        SceneManager.LoadScene("VersusScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
