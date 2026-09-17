using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BossEnemy : MonoBehaviour
{
    // 5
    public static event Action OnAnyBossSpawned;
    // 1
    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged;
    // 6
    public UnityEvent OnBossDefeated;

    public int currentHealth = 100;
    // 3
    private Action _onEnrage;
    public event Action OnEnrage
    {
        add
        {
            Debug.Log("Boss talking...");
            _onEnrage += value;
        }
        remove
        {
            Debug.Log("Boss stopped talking...");
            _onEnrage -= value;
        }
    }

    void Start()
    {
        // виклик стат. події при старті
        OnAnyBossSpawned?.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 40;
            TakeDamage(currentHealth);
        }
    }

    public void TakeDamage(int newHealth)
    {
        OnHealthChanged?.Invoke(newHealth);
        if (newHealth <= 50) TriggerEnrage();
        if (newHealth <= 0) Die();
    }

    private void TriggerEnrage()
    {
        _onEnrage.Invoke();
    }

    private void Die()
    {
        OnBossDefeated?.Invoke();
    }

    // 4
    public void ClearAllHealthSubscribers()
    {
        OnHealthChanged = null;
    }
}
