using Newtonsoft.Json;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public float health;
}

public class JsonTester : MonoBehaviour
{
    private string GetFilePath()
    {
        return Path.Combine(Application.streamingAssetsPath, "testPlayer.json");
    }

    private void Start()
    {
        TestJsonUtility();
        TestNewtonsoft();
    }

    private void TestJsonUtility()
    {
        Debug.Log("JSON UTILITY");
        PlayerData player = new PlayerData();
        player.playerName = "Sanya";
        player.level = 5;
        player.health = 75;

        Debug.Log("Created player");

        string jsonText = JsonUtility.ToJson(player, true);
        string path = GetFilePath();
        File.WriteAllText(path, jsonText);

        Debug.Log("File saved to: " + path);

        if (File.Exists(path))
        {
            string loadedText = File.ReadAllText(path);
            PlayerData loadedPlayer = JsonUtility.FromJson<PlayerData>(loadedText);

            Debug.Log($"Name: {loadedPlayer.playerName}, Level: {loadedPlayer.level}, Health: {loadedPlayer.health}");
        }
        else
        {
            Debug.Log("File not found!");
        }
    }

    private void TestNewtonsoft()
    {
        Debug.Log("NEWTONSOFT");
        PlayerData player = new PlayerData();
        player.playerName = "Lyosha";
        player.level = 5;
        player.health = 75;

        Debug.Log("Created player");

        string path = Path.Combine(Application.streamingAssetsPath, "newtonPlayer.json");

        string jsonText = JsonConvert.SerializeObject(player, Formatting.Indented);
        File.WriteAllText(path, jsonText);
        Debug.Log("File saved to: " + path);

        string loadedText = File.ReadAllText(path);
        PlayerData loadedPlayer = JsonConvert.DeserializeObject<PlayerData>(loadedText);
        Debug.Log($"Name: {loadedPlayer.playerName}, Level: {loadedPlayer.level}, Health: {loadedPlayer.health}");
    }
}

