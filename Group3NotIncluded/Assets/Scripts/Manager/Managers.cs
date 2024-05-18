using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    /*매니저 모음*/
    public static Managers Instance;
    private GameManager gameManager;
    private ScreenManager screenManager;
    private AudioManager audioManager;
    private EnemyManager enemyManager;

    /*이벤트 모음*/
    public event Action<bool> OnPause;
    public event Action OnGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            gameManager = gameObject.AddComponent<GameManager>();
            screenManager = gameObject.AddComponent<ScreenManager>();
            audioManager = gameObject.AddComponent<AudioManager>();
            enemyManager = gameObject.AddComponent<EnemyManager>();
        }
        else if (Instance != this) 
        {
            Destroy(this.gameObject); 
        }
    }

    public void OnPauseEvent(bool pause)
    {
        OnPause?.Invoke(pause);
    }

    public void OngameOverEvent()
    {
        OnGameOver?.Invoke();
    }
}