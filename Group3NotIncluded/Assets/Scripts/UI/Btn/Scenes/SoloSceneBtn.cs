using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloSceneBtn : MonoBehaviour
{
    public void LoadSoloScene()
    {
        SceneManager.LoadScene(1);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SoloScene ������ ��������� ����Ϸ��� �ش� �ε����� �����մϴ�.
        if (scene.name == "SoloScene")
        {
            AudioManager.Instance.PlayBackgroundMusic(1);
        }
    }

    public void PlayEffectSound()
    {
        //ȿ���� ���
        AudioManager.Instance.PlaySFX(0);
    }
}
