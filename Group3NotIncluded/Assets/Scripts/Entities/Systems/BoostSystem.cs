using System;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
	public event Action<float> BoostChangeEvent;

	private PlayerInputController controller;
	private PlayerStatHandler statHandler;

    public Animator boostanim;

	public float CurrentBoostGage { get; private set; }
    public bool CanBoost => CurrentBoostGage > 0;

	[SerializeField] private float boostConsume = 1f;
	[SerializeField] private float boostRecover = 1f;

    private float MaxBoostGage;
    private bool isBoosting;
    private bool boostButtonPressed;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
		statHandler = GetComponent<PlayerStatHandler>();
    }

    private void Start()
	{
        MaxBoostGage = statHandler.currentStat.maxBoostGage;
        CurrentBoostGage = MaxBoostGage;
        controller.OnBoostEvent += OnBoost;
        controller.OnBoostEvent += BoostAnim;
    }

	private void Update()
	{
		if (isBoosting)
		{
            if (CurrentBoostGage > 0)
            {
                ConsumeBoost();
            }
            else
            {
                isBoosting = false;
            }
        }
		else if (CurrentBoostGage < MaxBoostGage && !boostButtonPressed)
		{
			RecoverBoost();
		}

		BoostChangeEvent?.Invoke(CurrentBoostGage / MaxBoostGage);
	}

    public void OnBoost(bool onBoost)
    {
        boostButtonPressed = onBoost;

        if (onBoost && CurrentBoostGage > 0)
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }
    }

    public void BoostAnim(bool onBoost)
    {
        boostanim.SetBool("useBoost", onBoost);
    }

    public void OnBoostFullEvent()
    {
        CurrentBoostGage = MaxBoostGage;
    }

    private void ConsumeBoost()
	{
        CurrentBoostGage -= boostConsume * Time.deltaTime;
        if (CurrentBoostGage < 0)
        {
            CurrentBoostGage = 0;
        }
    }

	private void RecoverBoost()
	{
        CurrentBoostGage += boostRecover * Time.deltaTime;

        if (CurrentBoostGage > MaxBoostGage)
        {
            CurrentBoostGage = MaxBoostGage;
        }
    }
}