using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    /*�Ŵ��� ����*/
    public static Managers Instance;
    private GameManager gameManager;
    private ScreenManager screenManager;
    private AudioManager audioManager;
    private EnemyManager enemyManager;

    /*�̺�Ʈ ����*/
    public event Action OnPause;
    public event Action OnResume;
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

}