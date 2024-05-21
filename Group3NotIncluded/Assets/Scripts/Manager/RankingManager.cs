using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{

    private GameObject RankPanel;
    private List<KeyValuePair<string, int>> soloRankList = new List<KeyValuePair<string, int>>();//�̸�, ���� �����ϴ� ����Ʈ
    private GameObject SoloRankBox;
    private List<TextMeshProUGUI> soloRankDataList; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ����Ʈ

    private List<KeyValuePair<string, int>> coopRankList = new List<KeyValuePair<string, int>>();//�̸�, ���� �����ϴ� ����Ʈ
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
        string json = JsonConvert.SerializeObject(soloRankList);
        PlayerPrefs.SetString("SoloRankData", json);

        string coopjson = JsonConvert.SerializeObject(coopRankList);
        PlayerPrefs.SetString("CoopRankData", coopjson);

        PlayerPrefs.Save();
    }

    private void LoadDictionaryFromPlayerPrefs()
    {
        string json = PlayerPrefs.GetString("SoloRankData", "{}");
        if(json != "{}") soloRankList = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(json);

        string coopjson = PlayerPrefs.GetString("CoopRankData", "{}");
        if(coopjson != "{}") coopRankList = JsonConvert.DeserializeObject<List<KeyValuePair<string, int>>>(coopjson);
    }


    // �̸�, ���� ��� ���� �Լ�
    public void SetRankData(string playerName, int score)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "SoloScene")
        {
            soloRankList.Add(new KeyValuePair<string, int>(playerName, score));
        }
        else if (currentScene.name == "CoopScene")
        {
            coopRankList.Add(new KeyValuePair<string, int>(playerName, score));
        }


        // ������ ����
        SaveDictionaryToPlayerPrefs();

    }

    public void PrintSoloRankList()
    {
        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        var sortedScores = soloRankList.OrderByDescending(score => score.Value);

        // ���ĵ� ���� ���
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (soloRankDataList.Count > 7) break;

            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();
            TextMeshProUGUI data = Instantiate(RankData);
            data.transform.SetParent(SoloRankBox.transform, false); //������ ��ġ�� SoloRank�� �ڽ����� �̵�
            soloRankDataList.Add(data);
            i++;
        }

    }

    public void PrintCoopRankList()
    {

        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        CoopRankBox = RankPanel.transform.Find("CoopRank").transform.Find("Scroll View").transform.Find("Viewport").transform.Find("Content").gameObject;

        // ������ ������������ ����
        var sortedScores = coopRankList.OrderByDescending(score => score.Value);

        // ���ĵ� ���� ���
        int i = 0;
        foreach (var score in sortedScores)
        {
            if (coopRankDataList.Count > 7) break;

            RankData.text = "name: " + score.Key + "\n" + "score: " + score.Value.ToString();

            TextMeshProUGUI data = Instantiate(RankData);
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
