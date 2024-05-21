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
        // SoloScene 씬에서 배경음악을 재생하려면 해당 인덱스를 전달합니다.
        if (scene.name == "SoloScene")
        {
            AudioManager.Instance.PlayBackgroundMusic(1);
        }
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
