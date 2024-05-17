using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    public static Managers Instance;
    public LoginManager loginManager;
    public EnemyManager enemyManager;
    public AudioManager audioManager;
    public GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        loginManager = GetComponent<LoginManager>();
        enemyManager = GetComponent<EnemyManager>();
        audioManager = GetComponent<AudioManager>();
        gameManager = GetComponent<GameManager>();
    }

}