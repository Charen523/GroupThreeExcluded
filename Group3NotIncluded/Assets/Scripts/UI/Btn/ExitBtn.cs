using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();

#if UNITY_EDITOR
        // ����Ƽ �����Ͷ�� �̰͵� ����.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}