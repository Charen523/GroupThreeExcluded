using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    // ����� Inspector���� ������Ʈ(RankPanel�� SoloRank, CoopRank)�� �������� �־��ִ� ����. 
    // SoloScene���� �̵��ϸ� ������Ʈ�� �Ҹ�Ǵ� ������ ����. 
    // StartScene�� ���۵ɶ� �ڵ����� ������Ʈ�� �־��ֵ��� ���� �ʿ�

    public GameObject RankPanel;
    //�迭�� �ٲٰų� �ؼ� ��ŷ ������ ���� �̻� �Ѿ�� ������� �� �ʿ�����. �𸣸� Ʃ�� ã�ư���.
    //private List<float> soloRankTime; // �ð� ��ϵ� ������ ����Ʈ
    //private List<int> soloRankScore; // ���� ��ϵ� ������ ����Ʈ
    private Dictionary<string, int> soloRankData = new Dictionary<string, int>(); //�̸�, ���� �����ϴ� ��ųʸ�
    public GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ����Ʈ

    //���� ��������. �׸��� ������ ������ �� �� list�� �ƴ϶� dictionary�� �ؼ� �츮�� �Է¹��� �̸��� ���������� ���� �ʿ�.
    //private List<float> coopRankTime; // �ð� ��ϵ� ������ ����Ʈ
    //private List<int> coopRankScore; // ���� ��ϵ� ������ ����Ʈ
    private Dictionary<string, int> coopRankData = new Dictionary<string, int>(); //�̸�, ���� �����ϴ� ��ųʸ�
    public GameObject CoopRankBox;
    private List<TextMeshProUGUI> coopRankDataList; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ����Ʈ

    public TextMeshProUGUI RankData; // ��� ����ϴ� �ؽ�Ʈ ������


    private void Start()
    {


        //soloRankTime = new List<float>();
        //soloRankScore = new List<int>();

        soloRankDataList = new List<TextMeshProUGUI>();

        //coopRankTime = new List<float>();
        //coopRankScore = new List<int>();
        coopRankDataList = new List<TextMeshProUGUI>();

        //��� Ȯ�ο�
        SetRankData("kim", 1);
        SetRankData("park", 6);
        SetRankData("lee", 2);
        SetRankData("choi", 4); 
        SetRankData("kim2", 5);
        SetRankData("kang", 9);
        SetRankData("lee2", 7);
        SetRankData("default", 6);

        //��� Ȯ�ο�, �����δ� RankPanel�� Ȱ��ȭ �� �� ����
        //PrintSoloRankList();
        //PrintCoopRankList();
    }



    // �̸�, ���� ��� ���� �Լ�
    public void SetRankData(string name, int score)
    {
        soloRankData.Add(name, score);

        //��ųʸ� ������������ ����
        soloRankData = soloRankData.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

    }

    public void PrintSoloRankList()
    {
        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        int i = 0;
        foreach (KeyValuePair<string, int> item in soloRankData)
        {
            //��ŷ ȭ�鿡�� 8���� �̸�������(�ְ�������) ���
            if (soloRankDataList.Count > 7) break;

            Vector3 position = new Vector3(20, 250 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "name: " + item.Key + "\n" + "score: " + item.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(SoloRankBox.transform, false); //������ ��ġ�� SoloRank�� �ڽ����� �̵�
            soloRankDataList.Add(data);

            i++;
        }
    }

    public void PrintCoopRankList()
    {

        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        CoopRankBox = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        int i = 0;
        foreach (KeyValuePair<string, int> item in soloRankData)
        {
            //��ŷ ȭ�鿡�� 8���� �̸�������(�ְ�������) ���
            if (coopRankDataList.Count > 7) break;

            Vector3 position = new Vector3(20, 250 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "name: " + item.Key + "\n" + "score: " + item.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(CoopRankBox.transform, false); //������ ��ġ�� SoloRank�� �ڽ����� �̵�
            coopRankDataList.Add(data);

            i++;
        }
    }

    public void DestroyRankList()
    {
        //soloRank 
        soloRankDataList.Clear();
        Transform solo = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
        // SoloRank�� �ڽ� ������Ʈ�� ã��
        foreach (Transform child in solo)
        {
            // rankdata �±װ� ���� �ڽ� ������Ʈ�� ã�Ƽ� ����
            if (child.CompareTag("rankdata"))
            {
                Destroy(child.gameObject);
            }
        }

        //coopRank
        coopRankDataList.Clear();
        Transform coop = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content");
        // SoloRank�� �ڽ� ������Ʈ�� ã��
        foreach (Transform child in coop)
        {
            // rankdata �±װ� ���� �ڽ� ������Ʈ�� ã�Ƽ� ����
            if (child.CompareTag("rankdata"))
            {
                Destroy(child.gameObject);
            }
        }
    }
}
