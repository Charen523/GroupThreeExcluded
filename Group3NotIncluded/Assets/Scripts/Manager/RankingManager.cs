using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    // ����� Inspector���� ������Ʈ(RankPanel�� SoloRank, CoopRank)�� �������� �־��ִ� ����. 
    // SoloScene���� �̵��ϸ� ������Ʈ�� �Ҹ�Ǵ� ������ ����. 
    // StartScene�� ���۵ɶ� �ڵ����� ������Ʈ�� �־��ֵ��� ���� �ʿ�

    public GameObject RankPanel;
    //�迭�� �ٲٰų� �ؼ� ��ŷ ������ ���� �̻� �Ѿ�� ������� �� �ʿ�����. �𸣸� Ʃ�� ã�ư���.
    private List<float> soloRankTime; // �ð� ��ϵ� ������ ����Ʈ
    private List<int> soloRankScore; // ���� ��ϵ� ������ ����Ʈ
    public GameObject SoloRankBox;
    private Queue<TextMeshProUGUI> soloRankDataQueue; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ť

    //���� ��������. �׸��� ������ ������ �� �� list�� �ƴ϶� dictionary�� �ؼ� �츮�� �Է¹��� �̸��� ���������� ���� �ʿ�.
    private List<float> coopRankTime; // �ð� ��ϵ� ������ ����Ʈ
    private List<int> coopRankScore; // ���� ��ϵ� ������ ����Ʈ
    public GameObject CoopRankBox;
    private Queue<TextMeshProUGUI> coopRankDataQueue; // ��� ����ϴ� �ؽ�Ʈ ������ ��Ƴ��� ť

    public TextMeshProUGUI RankData; // ��� ����ϴ� �ؽ�Ʈ ������


    private void Start()
    {

        RankPanel = GameObject.Find("Canvas").transform.Find("RankPanel").gameObject;
        SoloRankBox = RankPanel.transform.Find("SoloRank").gameObject;
        CoopRankBox = RankPanel.transform.Find("CoopRank").gameObject;

        soloRankTime = new List<float>();
        soloRankScore = new List<int>();
        soloRankDataQueue = new Queue<TextMeshProUGUI>();

        coopRankTime = new List<float>();
        coopRankScore = new List<int>();
        coopRankDataQueue = new Queue<TextMeshProUGUI>();

        //��� Ȯ�ο�
        SetRankTime(10);
        SetRankScore(155);

        //��� Ȯ�ο�, �����δ� RankPanel�� Ȱ��ȭ �� �� ����
        PrintSoloRankList();
        PrintCoopRankList();
    }

    // �ð� ��� ���� �Լ�. GameOver�� ����
    public void SetRankTime(float time)
    {
        //�׽�Ʈ��
        soloRankTime.Add(time);
        coopRankTime.Add(time);
    }

    // ���� ��� ���� �Լ�. GameOver�� ����
    public void SetRankScore(int score)
    {
        //�׽�Ʈ��
        soloRankScore.Add(score);
        coopRankScore.Add(score);
    }


    public void PrintSoloRankList()
    {
        for (int i = 0; i < 5; i++) //for (int i = 0; i < ranktime.Count; i++), ����� ��� Ȯ�ο� 5���ݺ�
        {
            Vector3 position = new Vector3(0, 200 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            RankData.text = "time: " + soloRankTime[0].ToString() + "\n" + "score: " + soloRankScore[0].ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(SoloRankBox.transform, false); //������ ��ġ�� SoloRank�� �ڽ����� �̵�
            soloRankDataQueue.Enqueue(data);
        }
    }

    public void PrintCoopRankList()
    {

        for (int i = 0; i < 5; i++) //for (int i = 0; i < ranktime.Count; i++), ����� ��� Ȯ�ο� 5���ݺ�
        {
            Vector3 position = new Vector3(0, 200 - i * 100, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, 0); //�뵵?
            RankData.text = "time: " + soloRankTime[0].ToString() + "\n" + "score: " + soloRankScore[0].ToString();

            TextMeshProUGUI data = Instantiate(RankData, position, rotation);
            data.transform.SetParent(CoopRankBox.transform, false); //������ ��ġ�� CoopRank�� �ڽ����� �̵�
            coopRankDataQueue.Enqueue(data);
        }
    }
}
