using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance;

    [Header("PanelList")]
    public GameObject menuPanel;
    public GameObject rankPanel;

    [Header("SoloRank")]
    public TextMeshProUGUI[] soloName;
    public TextMeshProUGUI[] soloTime;

    [Header("CoopRank")]
    public TextMeshProUGUI[] CoopName;
    public TextMeshProUGUI[] CoopTime;

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


    public void LoadSoloMode()
    {
        SceneManager.LoadScene("SoloScene");
    }

    public void LoadCoopMode()
    {
        SceneManager.LoadScene("CoopScene");
    }

    public void LoadVersusMode()
    {
        SceneManager.LoadScene("VersusScene");
    }

}
