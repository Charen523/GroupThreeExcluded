using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "GameController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size; //�Ѿ� ũ��
    public float delay; //�Ѿ� ��
    public float power; //�Ѿ��� ������
    public float speed; //�Ѿ� �ӵ�
    public LayerMask target; //�Ѿ� ���

    [Header("Ranged Attack Data")]
    public string bulletNameTag; //Inspectorâ�� Tag
    public float duration; //�Ѿ� �Ÿ�(����ź ���)
    public float spread; //������ ����. �� ���� ����
    public int numberOfProjectilesPerShot; //�� ���� ����� �߻�ü ����
    public float multipleProjectilesAngle;  //�ִ� ����
    public Color projectileColor; //�߻�ü ����
}
