using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneBtn : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }
    void Start()
    {
        // 첫 번째 배경음악 재생
        AudioManager.Instance.PlayBackgroundMusic(0);
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
