using UnityEngine;

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

    }
}