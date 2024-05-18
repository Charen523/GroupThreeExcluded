using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    /*Hiearchy에서 부여안하면 자동으로 들어옴.*/
    public GameManager gameManager;
    public ScreenManager screenManager;
    public AudioManager audioManager;
    public EnemyManager enemyManager;

    /*이벤트 모음*/
    public event Action<bool> OnPause;
    public event Action OnGameOver;

    private bool isInitialized = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (gameManager == null)
            {
                gameManager = gameObject.AddComponent<GameManager>();
            }
            else
            {
                gameManager.GetComponent<GameManager>();
            }

            if (screenManager == null)
            {
                screenManager = gameObject.AddComponent<ScreenManager>();
            }
            else
            {
                screenManager.GetComponent<ScreenManager>();
            }

            if (audioManager == null)
            {
                audioManager = gameObject.AddComponent<AudioManager>();
            }
            else
            {
                audioManager.GetComponent<AudioManager>();
            }

            if (enemyManager == null)
            {
                enemyManager = gameObject.AddComponent<EnemyManager>();
            }
            else
            {
                enemyManager.GetComponent<EnemyManager>();
            }

            isInitialized = true; // 초기화 완료
        }
        else if (Instance != this) 
        {
            Destroy(this.gameObject); 
        }
    }

    public bool IsInitialized()
    {
        return isInitialized;
    }

    public void OnPauseEvent(bool pause)
    {
        OnPause?.Invoke(pause);
    }

    public void OnGameOverEvent()
    {
        OnGameOver?.Invoke();
    }
}