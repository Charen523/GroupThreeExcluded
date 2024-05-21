using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoopSceneBtn : MonoBehaviour
{
    public void LoadCoopScene()
    {
        SceneManager.LoadScene(2);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // SoloScene 씬에서 배경음악을 재생하려면 해당 인덱스를 전달합니다.
        if (scene.name == "CoopScene")
        {
            AudioManager.Instance.PlayBackgroundMusic(2);
        }
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
