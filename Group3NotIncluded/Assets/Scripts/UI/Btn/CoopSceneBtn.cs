using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoopSceneBtn : MonoBehaviour
{
    public void LoadCoopScene()
    {
        SceneManager.LoadScene(2);
    }

    void Start()
    {
        // 배경음악 재생
        AudioManager.Instance.PlayBackgroundMusic(2);
    }

    public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
