using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    public GameManager gameManager;
    public ScreenManager screenManager;
    public AudioManager audioManager;
    public RankingManager rankingManager;

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

            gameManager = gameObject.GetComponentInChildren<GameManager>();
            screenManager = gameObject.GetComponent<ScreenManager>();
            audioManager = gameObject.GetComponent<AudioManager>();
            rankingManager = GetComponent<RankingManager>();

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