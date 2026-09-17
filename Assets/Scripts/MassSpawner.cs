using UnityEngine;

public class MassSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    [Range(100, 100000)]
    public int spawnCount = 5000;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnmassiveAmount();
        }
    }

    private void SpawnmassiveAmount()
    {
        Debug.Log($"Spawning of {spawnCount} objects");
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(15f, 15f), 0, Random.Range(-15f, 15f));
            // better Object Pool instead
            Instantiate(objectPrefab, randomPos, Quaternion.identity);
        }
    }
}
