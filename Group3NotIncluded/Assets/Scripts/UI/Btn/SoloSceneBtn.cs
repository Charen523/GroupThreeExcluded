using UnityEngine;

public class SoloSceneBtn : MonoBehaviour
{
    public void LoadSoloScene()
    {
        Managers.Instance.screenManager.LoadSoloMode();
    }
}
