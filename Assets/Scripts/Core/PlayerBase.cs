using UnityEngine;
using System;

public class PlayerBase : MonoBehaviour, IDamageable
{
    public static PlayerBase Instance { get; private set; }
    public static event Action<int> OnHealthChanged;

    [SerializeField] private int _startingHealth = 100;
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        CurrentHealth = _startingHealth;
        OnHealthChanged?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (GameManager.Instance.IsGameOver) return;

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }

        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth == 0)
        {
            GameManager.Instance.EndGame();
        }
    }
}