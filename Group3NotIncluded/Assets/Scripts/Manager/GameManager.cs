using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //��ġ UI��ũ��Ʈ ������ �ٲ�� ��.
    //[Header ("UI")]
    //public TextMeshProUGUI gameScore;
    //public GameObject[] playerHpUI; 
    //public int playerHpCount;

    //[Header("PanelList")]
    //public GameObject menuPanel;
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel�� �� ����
    //public TextMeshProUGUI totalScore;
    //public TextMeshProUGUI endTime;

    //totalScore�� gameScore�� �и��� ����?

    private Managers managers;

    private bool isPaused;
    private int score;
    private float currentTime;

    private void Awake()
    {
        managers = GetComponent<Managers>();
    }

    // Start is called before the first frame update
    void Start()
    {
        managers.OnPause += GetPauseStatus;
        managers.OnGameOver += EndGame;

        Time.timeScale = 1f;
        currentTime = 0f;

        // �÷��̾� ���� ����

        //�÷��̾� Hp ����
        CreateHpUI();
    }


    // Update is called once per frame
    void Update()
    {
        //�ΰ��� �ð��� �帧 ���.
        currentTime += Time.deltaTime;
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

    public float GetTime()
    {
        return currentTime;
    }

    // ���� óġ�� �� ���� ȣ��
    // ���� ����
    public void AddScore()
    {
        score++; // ���� ��� ��Ŀ� ���� ���� �ʿ�
        //������ȭ�� �̺�Ʈ�� ����.
        //gameScore.text = score.ToString();
    }

    //HealthSystem�� �����ϴ� ������ ���� �ʿ�.
    // �÷��̾ ���ݿ� ���� �� ���� ȣ��
    // �÷��̾� Hp UI 1�� �Ҹ�
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
}
