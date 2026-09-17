using UnityEngine;

// 2 - клас підписник
public class BossUI : MonoBehaviour
{
    public BossEnemy currentBoss;

    void OnEnable()
    {
        BossEnemy.OnAnyBossSpawned += ShowWarningMessage;
        if (currentBoss != null)
        {
            currentBoss.OnHealthChanged += UpdateHealthBar;
            currentBoss.OnEnrage += TurnScreenRed;
        }
    }

    void OnDisable()
    {
        BossEnemy.OnAnyBossSpawned -= ShowWarningMessage;
        if (currentBoss != null)
        {
            currentBoss.OnHealthChanged -= UpdateHealthBar;
            currentBoss.OnEnrage -= TurnScreenRed;
            currentBoss.ClearAllHealthSubscribers();
        }
    }

    private void ShowWarningMessage()
    {
        Debug.Log("The boss has spawned");
    }
    private void UpdateHealthBar(int hp)
    {
        Debug.Log($"Health updated: {hp}");
    }
    private void TurnScreenRed()
    {
        Debug.Log("Screen became red");
    }
}
