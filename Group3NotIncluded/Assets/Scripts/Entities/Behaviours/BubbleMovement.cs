using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private BubbleController bubbleController;
    private Transform closestPlayer;
    private Rigidbody2D rb;
    private Vector2 targetDirection;

    [Header("BubbleMovement")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float wobbleIntensity = 0.7f;
    [SerializeField] private float wobbleSpeed = 5f;

    private void Start()
    {
        bubbleController = FindObjectOfType<BubbleController>();
        rb = GetComponent<Rigidbody2D>();
        FindClosestPlayer();

        if (closestPlayer != null)
        {
            targetDirection = (closestPlayer.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        ApplyWobbleMovement();
    }

    private void ApplyWobbleMovement()
    {
        float wobbleAngle = Mathf.Sin(Time.time * wobbleSpeed) * wobbleIntensity;
        Vector2 wobbleOffset = new Vector2(Mathf.Cos(wobbleAngle), Mathf.Sin(wobbleAngle)) * wobbleIntensity;
        rb.velocity = (targetDirection + wobbleOffset).normalized * speed;
    }

    private void FindClosestPlayer()
    {
        GameObject[] players = bubbleController.players;

        if (players[0] == null && players[1] == null)
        {
            return;
        }
        else if (players[1] == null)
        {
            closestPlayer = players[0].transform;
            return;
        }
        else if (players[0] == null)
        {
            closestPlayer = players[1].transform;
            return;
        }

        //멀티라면.
        float distance1 = Vector2.Distance(transform.position, players[0].transform.position);
        float distance2 = Vector2.Distance(transform.position, players[1].transform.position);

        int playerNum = distance1 > distance2? 1 : 0;

        if (playerNum == 0)
            closestPlayer = players[0].transform;
        else
            closestPlayer = players[1].transform;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HandlePlayerCollision(collision.gameObject);
        }
        else if (collision.gameObject.layer == 6 || collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    private void HandlePlayerCollision(GameObject player)
    {
        string iconName = GetComponentInChildren<SpriteRenderer>().sprite.name;
        Destroy(gameObject);
        ExecutePowerUp(iconName, player);
    }

    private void ExecutePowerUp(string iconName, GameObject player)
    {
        switch (iconName)
        {
            case "Icon0":
                HandleNoBulletPowerUp(player);
                break;
            case "Icon1":
                player.GetComponent<PlayerHealthSystem>().EnableHP();
                AudioManager.Instance.PlaySFX(8);
                break;
            case "Icon2":
                player.GetComponent<PlayerHealthSystem>().OnInvincibleEvent();
                AudioManager.Instance.PlaySFX(10);
                break;
            case "Icon3":
                player.GetComponent<BoostSystem>().OnBoostFullEvent();
                AudioManager.Instance.PlaySFX(7);
                break;
            case "Icon4":
                player.GetComponent<PlayerStatHandler>().GetMultiShot();
                AudioManager.Instance.PlaySFX(9);
                break;
            default:
                break;
        }
    }

    private void HandleNoBulletPowerUp(GameObject player)
    {
        player.GetComponent<Animator>().SetTrigger("NoBullet");
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            bullet.SetActive(false);
        }
        AudioManager.Instance.PlaySFX(11);
    }
}
