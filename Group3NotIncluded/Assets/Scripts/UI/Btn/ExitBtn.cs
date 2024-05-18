using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();

#if UNITY_EDITOR
        // 유니티 에디터라면 이것도 종료.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}