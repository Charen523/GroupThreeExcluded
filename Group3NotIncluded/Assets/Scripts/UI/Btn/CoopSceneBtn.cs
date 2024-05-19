using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoopSceneBtn : MonoBehaviour
{
    public void LoadCoopScene()
    {
        SceneManager.LoadScene(2);
    }
}
