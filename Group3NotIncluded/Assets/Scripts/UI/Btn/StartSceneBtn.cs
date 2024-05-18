using UnityEngine;

public class StartSceneBtn : MonoBehaviour
{
    public void LoadStartScene()
    {
        Managers.Instance.screenManager.LoadStartScene();
    }
}
