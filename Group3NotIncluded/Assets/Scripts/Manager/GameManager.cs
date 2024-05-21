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


    // 점수 계산용 
    private float scoreFactor1 = 199f;
    private float scoreFactor2 = 1.7f;
    private int maxScore = 99999;
    private float killScore = 500f;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //씬 로드 시 데이터 초기화.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeGameData();
    }
    
    void Start()
    {
        InitializeGameData(); //게임 초기화
        
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
        //인게임 시간의 흐름 계산.
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
        isPaused = pause; //추후 필요없으면 삭제.

        if (isPaused)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }

    //currentTime을 timeText에 전달하는 메서드.
    public float GetTime()
    {
        return currentTime;
    }

    // 점수 증가
    public void AddKillCount(GameObject obj)
    {
        currentKillCount += obj.Equals(null) ? 0 : obj.GetComponent<EnemyHealthSystem>().CallScore();
        //currentScore += score;
    }

    public int GetScore()
    {
        // 점수 계산 로직, 현재 시간 * 199 * 1.7 (소수점 버림) + (적 처치 수 * 500) (Max 99999)
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

    //게임종료 이벤트.
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
