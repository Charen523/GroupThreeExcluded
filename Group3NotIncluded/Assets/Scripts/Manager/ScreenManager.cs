using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScreenManager : MonoBehaviour
{
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
