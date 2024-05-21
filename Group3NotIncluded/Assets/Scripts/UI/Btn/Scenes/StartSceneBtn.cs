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
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SoloScene 씬에서 배경음악을 재생하려면 해당 인덱스를 전달합니다.
        if (scene.name == "StartScene")
        {
            AudioManager.Instance.PlayBackgroundMusic(0);
        }
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
