using UnityEngine;

public class DebugTester : MonoBehaviour
{
    void Start()
    {
        int playerHealth = 100;
        int damage = 30;
        int armor = 40;

        int actualDamage = armor - damage; // damage - armor

        if (actualDamage < 0)
        {
            actualDamage = 0;
        }

        playerHealth -= actualDamage;

        Debug.Log("Health: " + playerHealth);
    }
}