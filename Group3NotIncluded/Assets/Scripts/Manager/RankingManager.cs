using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{

    private GameObject RankPanel;
    private Dictionary<string, List<int>> soloRankData = new Dictionary<string, List<int>>(); //�̸�, ���� �����ϴ� ��ųʸ�
    private GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ����Ʈ

    private Dictionary<string, List<int>> coopRankData = new Dictionary<string, List<int>>(); //�̸�, ���� �����ϴ� ��ųʸ�
    private GameObject CoopRankBox;
    private List<TextMeshProUGUI> coopRankDataList; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ����Ʈ

    public TextMeshProUGUI RankData; // ��� ����ϴ� �ؽ�Ʈ ������


 
    private void Start()
    {
        soloRankDataList = new List<TextMeshProUGUI>();
        coopRankDataList = new List<TextMeshProUGUI>();

        // ������ �ε�
        LoadDictionaryFromPlayerPrefs();
    }

    public void SaveDictionaryToPlayerPrefs()
    {
        string json = JsonConvert.SerializeObject(soloRankData);
        PlayerPrefs.SetString("SoloRankData", json);
        PlayerPrefs.Save();
    }

    private void LoadDictionaryFromPlayerPrefs()
    {
        string json = PlayerPrefs.GetString("SoloRankData", "{}");
        soloRankData = JsonConvert.DeserializeObject<Dictionary<string, List<int>>>(json);
    }


    // �̸�, ���� ��� ���� �Լ�
    public void SetRankData(string playerName, int score)
    {
        if (soloRankData.ContainsKey(playerName))
        {
            // �̹� �����ϴ� Ű�� ���� �߰�
            soloRankData[playerName].Add(score);
        }
        else
        {
            // ���ο� Ű-�� �� �߰�
            soloRankData.Add(playerName, new List<int> { score });
        }

        // ������ ����
        SaveDictionaryToPlayerPrefs();

    }

    public void PrintSoloRankList()
    {
        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;


        // ��� ������ �÷��̾� �̸��� ������ ������ ����Ʈ ����
        List<KeyValuePair<string, int>> allScores = new List<KeyValuePair<string, int>>();

        // ��ųʸ����� ��� �÷��̾�� ������ ����Ʈ�� �߰�
        foreach (var entry in soloRankData)
        {
            foreach (var score in entry.Value)
            {
                allScores.Add(new KeyValuePair<string, int>(entry.Key, score));
            }
        }

        // ������ ������������ ����
        var sortedScores = allScores.OrderByDescending(score => score.Value);


        // ���ĵ� ���� ���
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (soloRankDataList.Count > 7) break;

                Vector3 position = new Vector3(20, 250 - i * 100, 0);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

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

        // ��� ������ �÷��̾� �̸��� ������ ������ ����Ʈ ����
        List<KeyValuePair<string, int>> allScores = new List<KeyValuePair<string, int>>();

        // ��ųʸ����� ��� �÷��̾�� ������ ����Ʈ�� �߰�
        foreach (var entry in coopRankData)
        {
            foreach (var score in entry.Value)
            {
                allScores.Add(new KeyValuePair<string, int>(entry.Key, score));
            }
        }

        // ������ ������������ ����
        var sortedScores = allScores.OrderByDescending(score => score.Value);


        // ���ĵ� ���� ���
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (coopRankDataList.Count > 7) break;

            Vector3 position = new Vector3(20, 250 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(SoloRankBox.transform, false); //������ ��ġ�� SoloRank�� �ڽ����� �̵�
            soloRankDataList.Add(data);

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
