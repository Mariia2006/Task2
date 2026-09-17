using UnityEngine;

// автоматичне додавання Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerConfig : MonoBehaviour
{
    [Header("Базові налаштування")]

    // поміняти приватне поле в редакторі
    [SerializeField]
    private string playerName = "Unknown";

    // Range - зробити з поля повзунок з обмеженими значеннями
    [SerializeField, Range(1, 100)]
    private int maxHealth = 100;

    [Space(20)] // відступ перед наступною групою змінних

    [Header("Технічні дані")]
    [Tooltip("Не для використання")]

    // публічна, але невидима в інспекторі
    [HideInInspector]
    public float runtimeSpeed;

    [Space(10)]
    [SerializeField]
    private StartingGear startEquipment;
}

// Щоб клас відображався в інспекторі як поля змінної startEquipment, потрібен цей атрибут
[System.Serializable]
public class StartingGear
{
    public string weaponName = "Wooden Sword";
    public int healthPotions = 3;
}