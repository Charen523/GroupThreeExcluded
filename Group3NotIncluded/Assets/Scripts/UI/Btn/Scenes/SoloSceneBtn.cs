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

    void Start()
    {
        // 첫 번째 배경음악 재생
        AudioManager.Instance.PlayBackgroundMusic(1);
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
