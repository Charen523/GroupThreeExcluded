using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VersusSceneBtn : MonoBehaviour
{
    public void LoadVersusScene()
    {
        SceneManager.LoadScene(3);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }
    void Start()
    {
        // ������� ���
        AudioManager.Instance.PlayBackgroundMusic(3);
    }

    public void PlayEffectSound()
    {
        //ȿ���� ���
        AudioManager.Instance.PlaySFX(0);
    }
}
