using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloSceneBtn : MonoBehaviour
{
    public AudioClip[] sceneBackgroundMusics;

    public void LoadSoloScene()
    {
        SceneManager.LoadScene(1);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }
        public void PlayEffectSound()
    {
        //효과음 재생
        AudioManager.Instance.PlaySFX(0);
    }
}
