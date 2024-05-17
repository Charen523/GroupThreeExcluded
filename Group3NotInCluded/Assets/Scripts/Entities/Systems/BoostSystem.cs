using System;
using UnityEngine;

public class BoostSystem : MonoBehaviour
{
	public event Action<float> BoostChangeEvent;

	private PlayerInputController controller;
	private PlayerStatHandler statHandler;

	public float CurrentBoostGage { get; private set; }
    
	[SerializeField] private float boostConsume = 2f;
	[SerializeField] private float boostRecover = 0.5f;

    private float MaxBoostGage;
    private bool isBoosting;

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
		statHandler = GetComponent<PlayerStatHandler>();
        MaxBoostGage = statHandler.currentStat.maxBoostGage;
        CurrentBoostGage = MaxBoostGage;
    }

    private void Start()
	{
        controller.OnBoostEvent += OnBoost;
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
		else
		{
			RecoverBoost();
		}

		BoostChangeEvent?.Invoke(CurrentBoostGage / MaxBoostGage);
	}

    public void OnBoost(bool onBoost)
    {
        if (onBoost && CurrentBoostGage > 0)
        {
            isBoosting = true;
        }
        else
        {
            isBoosting = false;
        }
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
		if (!isBoosting && CurrentBoostGage < MaxBoostGage)
		{
            CurrentBoostGage += boostRecover * Time.deltaTime;

            if (CurrentBoostGage > MaxBoostGage)
			{
				CurrentBoostGage = MaxBoostGage;
			}
		}
	}
}