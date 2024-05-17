using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultAttackSO", menuName = "GameController/Attacks/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size; //총알 크기
    public float delay; //총알 빈도
    public float power; //총알의 데미지
    public float speed; //총알 속도
    public LayerMask target; //총알 대상

    [Header("Ranged Attack Data")]
    public string bulletNameTag; //Inspector창의 Tag
    public float duration; //총알 거리(유도탄 대비)
    public float spread; //퍼지는 정도. 뺄 수도 있음
    public int numberOfProjectilesPerShot; //한 번에 쏘아질 발사체 개수
    public float multipleProjectilesAngle;  //최대 각도
    public Color projectileColor; //발사체 색깔
}
