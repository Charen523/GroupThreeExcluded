using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public ScreenManager sceneManager;
    public EnemyManager enemyManager;
    public AudioManager audioManager;
    public GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) 
        {
            Destroy(this.gameObject); 
        }

        sceneManager = GetComponent<ScreenManager>();
        enemyManager = GetComponent<EnemyManager>();
        audioManager = GetComponent<AudioManager>();
        gameManager = GetComponent<GameManager>();
    }

}