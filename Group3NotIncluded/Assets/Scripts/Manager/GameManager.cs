using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Managers managers;

    private bool isPaused;
    private int currentScore;
    private float currentTime;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //�� �ε� �� ������ �ʱ�ȭ.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeGameData();
    }
    
    void Start()
    {
        InitializeGameData(); //���� �ʱ�ȭ
        
        managers = Managers.Instance;
        managers.OnPause += GetPauseStatus;
        managers.OnEnemyDie += AddScore;
        managers.OnGameOver += EndGame;
    }

    void Update()
    {
        //�ΰ��� �ð��� �帧 ���.
        currentTime += Time.deltaTime;
    }

    private void InitializeGameData()
    {
        Time.timeScale = 1f;
        currentTime = 0f;
        currentScore = 0;
        isPaused = false;
        //CreateHpUI();
    }

    private void GetPauseStatus(bool pause)
    {
        isPaused = pause; //���� �ʿ������ ����.

        if (isPaused)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    // ������ȭ �� Hp UI�� playerHpCount�� ��ŭ ����
    // Ư�� ��ǥ�� ������ ����, n��ŭ x��ǥ �̵�
    private void CreateHpUI()
    {
        Vector3 position = new Vector3(10f, 0f, 0f); //��ǥ ���� �ʿ�!
    }

    //currentTime�� timeText�� �����ϴ� �޼���.
    public float GetTime()
    {
        return currentTime;
    }

    // ���� ����
    public void AddScore(int score)
    {
        currentScore += score;   
    }

    public int GetScore()
    {
        return currentScore;
    }

    //�������� �̺�Ʈ.
    public void EndGame()
    {
        Time.timeScale = 0f;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }

}
