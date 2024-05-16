using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header ("UI")]
    public TextMeshProUGUI timer;
    public TextMeshProUGUI gameScore;
    public GameObject[] playerHpUI; 
    public int playerHpCount;

    [Header("PanelList")]
    public GameObject menuPanel;
    public GameObject endPanel;

    [Header("EndPanel")] //EndPanel�� �� ����
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI endTime;

    private int score;
    private float nowtime;

    private void Awake()
    {
        // GameManager �̱���
        if (Instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            Instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else if (Instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
        {
            Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        // �÷��̾� ���� ����

        //�÷��̾� Hp ����
        CreateHpUI();
    }


    // Update is called once per frame
    void Update()
    {
        // ���� �ð� UI�� ǥ��
        nowtime += Time.deltaTime;
        timer.text = nowtime.ToString("N2");

        // ���� ���� ����(Invoke �Ǵ� Couroutine ����Ͽ� �ð��� �α�)

        // Ư�� ���� �޼�(�÷��̾� ü�� 0)�� ���� ����
        //if (playerHpCount <= 0)
        //{
        //    EndGame();
        //}
    }

    // ������ȭ �� Hp UI�� playerHpCount�� ��ŭ ����
    // Ư�� ��ǥ�� ������ ����, n��ŭ x��ǥ �̵�
    private void CreateHpUI()
    {
        Vector3 position = new Vector3(10f, 0f, 0f); //��ǥ ���� �ʿ�!
    }

    // ���� óġ�� �� ���� ȣ��
    // ���� ����
    public void AddScore()
    {
        score++; // ���� ��� ��Ŀ� ���� ���� �ʿ�
        gameScore.text = score.ToString();
    }

    // �÷��̾ ���ݿ� ���� �� ���� ȣ��
    // �÷��̾� Hp UI 1�� �Ҹ�
    public void DecreaseHp()
    {
        Destroy(playerHpUI[playerHpCount - 1]);
        playerHpCount--;
    }


    // ���� ���� �� EndPanel ����
    public void EndGame()
    {
        Time.timeScale = 0;
        endTime.text = timer.text;
        totalScore.text = gameScore.text;
        endPanel.SetActive(true);
    }
}
