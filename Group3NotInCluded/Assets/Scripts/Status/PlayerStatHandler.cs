using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStat baseStat;
    public PlayerStat currentStat { get; private set; }
    //���ǿ� �ִ� �ǵ� �Ƹ� ���꿡 ����. 
    //����: ���� �߻��� ����Ʈ�� �߰��ؼ� ���?
    //public List<CharacterStat> statsModifiers = new List<CharacterStat>();

    private void Awake()
    {
        UpdatePlayerStat();
    }

    private void UpdatePlayerStat()
    {
        currentStat = new PlayerStat();

        currentStat.statsChangeType = baseStat.statsChangeType;
        currentStat.maxHealth = baseStat.maxHealth;
        currentStat.speed = baseStat.speed;
        currentStat.bulletSpeed = baseStat.bulletSpeed;
        currentStat.bulletFrequency = baseStat.bulletFrequency;
        currentStat.boostGage = baseStat.boostGage;
    }
}