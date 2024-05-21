using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelBtn : MonoBehaviour
{
    public void LoadStartScene()
    {
        Managers.Instance.gameManager.RegisterDataToRank();

        SceneManager.LoadScene(0);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
        AudioManager.Instance.PlaySFX(0);
    }

    public void LoadSoloScene()
    {
        Managers.Instance.gameManager.RegisterDataToRank();

        SceneManager.LoadScene(1);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
        AudioManager.Instance.PlaySFX(0);
    }


    public void LoadCoopScene()
    {
        Managers.Instance.gameManager.RegisterDataToRank();

        SceneManager.LoadScene(2);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }

    public void LoadVersusScene()
    {
        Managers.Instance.gameManager.RegisterDataToRank();

        SceneManager.LoadScene(3);

        if (Managers.Instance.enemyManager == null) return;
        Managers.Instance.enemyManager.ClearEnemyManager();
    }

}
