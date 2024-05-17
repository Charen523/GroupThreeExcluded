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
    //public TextMeshProUGUI timer;
    //public TextMeshProUGUI gameScore;
    //public GameObject[] playerHpUI; 
    //public int playerHpCount;

    //[Header("PanelList")]
    //public GameObject menuPanel;
    //public GameObject endPanel;

    //[Header("EndPanel")] //EndPanel�� �� ����
    //public TextMeshProUGUI totalScore;
    //public TextMeshProUGUI endTime;

    //totalScore�� gameScore�� �и�?

    private int score;
    private float currentTime;

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
        currentTime += Time.deltaTime;
        //timer.text = currentTime.ToString("N2");

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


    // ���� ���� �� EndPanel ����
    //Evenet�� EndPanel�ʿ� ��ȣ ������ ������?
    public void EndGame()
    {
        Time.timeScale = 0f;
        //�������� �̺�Ʈ.
        //endTime.text = timer.text;
        //totalScore.text = gameScore.text;
        //endPanel.SetActive(true);
    }
}
