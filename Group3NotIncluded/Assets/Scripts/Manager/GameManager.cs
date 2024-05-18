using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //��ġ UI��ũ��Ʈ ������ �ٲ�� ��.
    //[Header ("UI")]
    //public TextMeshProUGUI gameScore;//�̷��� ���̾������ӿ� ���µ�.
    //public GameObject[] playerHpUI; 
    //public int playerHpCount; �̰� �� public?

    //[Header("PanelList")]
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel�� �� ����
    //public TextMeshProUGUI totalScore; //gameScore �и� ����?
    //public TextMeshProUGUI endTime; //����?

    private Managers managers;

    private bool isPaused;
    private int score;
    private float currentTime;

    // �÷��̾� ��ġ
    [SerializeField] private Transform[] playerPos = new Transform[2];
    public ObjectPool ObjectPool { get; private set; }  // ������Ʈ Ǯ

    private void Awake()
    {
        managers = GetComponent<Managers>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        playerPos[0] = GameObject.FindGameObjectsWithTag("Player")[0].transform;

        ObjectPool = GetComponent<ObjectPool>();
    }

    //�� �ε� �� ������ �ʱ�ȭ.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeGameData();
    }
    
    void Start()
    {
        managers.OnPause += GetPauseStatus;
        managers.OnGameOver += EndGame;

        InitializeGameData(); //���� �ʱ�ȭ
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
        score = 0;
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
    public void AddScore()
    {
        score++; // ���� ��� ��Ŀ� ���� ���� �ʿ�
        //������ȭ�� �̺�Ʈ�� ����.
        //gameScore.text = score.ToString();
    }

    //HealthSystem�� �����ϴ� ������ ���� �ʿ�.
    // �÷��̾ ���ݿ� ���� �� ���� ȣ��
    //public void DecreaseHp()
    //{
    //    Destroy(playerHpUI[playerHpCount - 1]);
    //    playerHpCount--;
    //}

    //�������� �̺�Ʈ.
    public void EndGame()
    {
        Time.timeScale = 0f;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }

    // �÷��̾� ��ġ ��ȯ
    public Transform CallPlayerPos(int num = 0)
    {
        return playerPos[num];
    }
}
