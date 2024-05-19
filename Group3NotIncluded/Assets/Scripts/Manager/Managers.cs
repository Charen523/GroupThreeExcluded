using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    /*Hiearchy���� �ο����ϸ� �ڵ����� ����.*/
    public GameManager gameManager;
    public ScreenManager screenManager;
    public AudioManager audioManager;
    public RankingManager rankingManager;

    /*�̺�Ʈ ����*/
    public event Action<bool> OnPause;
    public event Action OnGameOver;

    private bool isInitialized = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            gameManager = gameObject.AddComponent<GameManager>();
            screenManager = gameObject.AddComponent<ScreenManager>();

            //inspectorâ���� �ο��ϸ� �ȸ���.
            if (audioManager == null)
                audioManager = gameObject.AddComponent<AudioManager>();

            //inspectorâ���� �ο��ϸ� ���� �ȸ���.
            if (rankingManager == null)
            {
                rankingManager = gameObject.AddComponent<RankingManager>();
            }

            isInitialized = true; // �ʱ�ȭ �Ϸ�
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