using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private AttackSO attackData;
    private float currendDuration;
    private Vector2 direction;

    private Rigidbody2D _rigidbody;

    public void InitializeAttack(Vector2 direction, AttackSO attackData)
    {
        this.direction = direction;
        this.attackData = attackData;
        currendDuration = attackData.duration;
    }
}