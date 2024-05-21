using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Managers managers;

    private bool isPaused;
    private int currentKillCount;
    private string playerName;
    private float currentTime;

    private TMP_Text scoreTxt;
    private TMP_InputField playerNameTxt;
    private GameObject endPanel;


    // ���� ���� 
    private float scoreFactor1 = 199f;
    private float scoreFactor2 = 1.7f;
    private int maxScore = 99999;
    private float killScore = 500f;

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
        managers.OnEnemyDie += AddKillCount;

        managers.OnGameOver += EndGame;
        managers.OnGameOver += FindTextLabel;
        managers.OnGameOver += UpdateScoreText;
        managers.OnGameOver += FindEndPanel;
        managers.OnGameOver += SetEndPanel;

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
        currentKillCount = 0;
        playerName = "";
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

    //currentTime�� timeText�� �����ϴ� �޼���.
    public float GetTime()
    {
        return currentTime;
    }

    // ���� ����
    public void AddKillCount(GameObject obj)
    {
        currentKillCount += obj.Equals(null) ? 0 : obj.GetComponent<EnemyHealthSystem>().CallScore();
        //currentScore += score;
    }

    public int GetScore()
    {
        // ���� ��� ����, ���� �ð� * 199 * 1.7 (�Ҽ��� ����) + (�� óġ �� * 500) (Max 99999)
        return
            Mathf.Min(Mathf.FloorToInt((currentTime * scoreFactor1 * scoreFactor2) + (currentKillCount * killScore)), maxScore); ;
    }

    public string GetName()
    {
        playerNameTxt = GameObject.Find("Canvas").transform.Find("EndPanel").transform.Find("RankContainer").Find("NameInput").GetComponent<TMP_InputField>();
        playerName = playerNameTxt.text;
        if (playerName == "")
            return "default";
        else
            return playerName;
    }
    public void RegisterDataToRank()
    {
        managers.rankingManager.SetRankData(GetName(),GetScore());
    }

    //�������� �̺�Ʈ.
    public void EndGame()
    {
        Time.timeScale = 0f;
    }

    public void FindTextLabel()
    {
        scoreTxt = GameObject.Find("Canvas").transform.Find("EndPanel").transform.Find("Score").Find("ScoreTxt").GetComponent<TMP_Text>();
    }

    public void UpdateScoreText()
    {
        scoreTxt.text = GetScore().ToString("D5");
    }

    public void FindEndPanel()
    {
        endPanel = GameObject.Find("Canvas").transform.Find("EndPanel").gameObject;
    }

    public void SetEndPanel()
    {
        endPanel.SetActive(true);
    }
}
