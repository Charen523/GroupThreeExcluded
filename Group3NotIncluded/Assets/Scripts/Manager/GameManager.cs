using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //위치 UI스크립트 쪽으로 바꿔야 함.
    //[Header ("UI")]
    //public TextMeshProUGUI gameScore;//이런거 와이어프레임엔 없는데.
    //public GameObject[] playerHpUI; 
    //public int playerHpCount; 이거 왜 public?

    //[Header("PanelList")]
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel에 들어갈 정보
    //public TextMeshProUGUI totalScore; //gameScore 분리 이유?
    //public TextMeshProUGUI endTime; //굳이?

    private Managers managers;

    private bool isPaused;
    private int score;
    private float currentTime;

    // 플레이어 위치
    [SerializeField] private Transform[] playerPos = new Transform[2];
    public ObjectPool ObjectPool { get; private set; }  // 오브젝트 풀

    private void Awake()
    {
        managers = GetComponent<Managers>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        playerPos[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        ObjectPool = GetComponent<ObjectPool>();
    }

    //씬 로드 시 데이터 초기화.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeGameData();
    }
    
    void Start()
    {
        managers.OnPause += GetPauseStatus;
        managers.OnGameOver += EndGame;

        InitializeGameData(); //게임 초기화
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
        score = 0;
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

    // 프리펩화 한 Hp UI를 playerHpCount수 만큼 생성
    // 특정 좌표에 프리펩 생성, n만큼 x좌표 이동
    private void CreateHpUI()
    {
        Vector3 position = new Vector3(10f, 0f, 0f); //좌표 수정 필요!
    }

    //currentTime을 timeText에 전달하는 메서드.
    public float GetTime()
    {
        return currentTime;
    }

    // 점수 증가
    public void AddScore()
    {
        score++; // 점수 계산 방식에 따라 조정 필요
        //점수변화를 이벤트로 전송.
        //gameScore.text = score.ToString();
    }

    //HealthSystem과 연계하는 것으로 수정 필요.
    // 플레이어가 공격에 맞을 때 마다 호출
    //public void DecreaseHp()
    //{
    //    Destroy(playerHpUI[playerHpCount - 1]);
    //    playerHpCount--;
    //}

    //게임종료 이벤트.
    public void EndGame()
    {
        Time.timeScale = 0f;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }

    // 플레이어 위치 반환
    public Transform CallPlayerPos(int num = 0)
    {
        return playerPos[num];
    }
}
