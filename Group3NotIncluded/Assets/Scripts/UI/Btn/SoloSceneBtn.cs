using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloSceneBtn : MonoBehaviour
{
    public void LoadSoloScene()
    {
        Managers.Instance.screenManager.LoadSoloMode();
    }
}
