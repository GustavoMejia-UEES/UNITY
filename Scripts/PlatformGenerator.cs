using UnityEngine;
using System.Collections.Generic;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Configuraciones de las plataformas")]
    public GameObject[] platformPrefabs; 
    public float minSpawnDistance = 2f; 
    public float maxSpawnDistance = 5f; 
    public float minHeight = -2f; 
    public float maxHeight = 2f;

    [Header("Configuraciones de monedas y enemigos")]
    public GameObject coinPrefab; 
    public GameObject enemyPrefab; 
    public float coinSpawnChance = 0.5f; 
    public float enemySpawnChance = 0.3f; 

    [Header("Configuraciones del jugador")]
    public Transform player; 
    public float spawnAheadDistance = 10f; 
    [Header("Reciclaje de plataformas")]
    public float recycleDistance = 15f; 
    private float lastSpawnX; 
    private Queue<GameObject> activePlatforms = new Queue<GameObject>(); 

    void Start()
    {
        lastSpawnX = player.position.x;
        GenerateInitialPlatforms();
    }

    void Update()
    {
        GeneratePlatforms();
        RecyclePlatforms();
    }

    void GeneratePlatforms()
    {
        while (player.position.x + spawnAheadDistance > lastSpawnX)
        {
            GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

            float spawnX = lastSpawnX + Random.Range(minSpawnDistance, maxSpawnDistance);
            float spawnY = Random.Range(minHeight, maxHeight);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            activePlatforms.Enqueue(newPlatform); 
            SpawnCoin(newPlatform);
            SpawnEnemy(newPlatform);

            lastSpawnX = spawnX;
        }
    }

    [Header("Altura de monedas y enemigos")]
    public float coinOffsetY = 1.5f; 

    void SpawnCoin(GameObject platform)
    {
    if (Random.value < coinSpawnChance)
    {
        Renderer platformRenderer = platform.GetComponent<Renderer>();
        float platformWidth = platformRenderer.bounds.size.x;

        float coinX = platform.transform.position.x + Random.Range(-platformWidth / 2f, platformWidth / 2f);
        float coinY = platform.transform.position.y + coinOffsetY; 
        Vector3 coinPosition = new Vector3(coinX, coinY, 0);

        Instantiate(coinPrefab, coinPosition, Quaternion.identity);
    }
    }

    public float enemyOffsetY = 1.2f; 

    void SpawnEnemy(GameObject platform)
    {
    if (Random.value < enemySpawnChance)
    {
        Renderer platformRenderer = platform.GetComponent<Renderer>();
        float platformWidth = platformRenderer.bounds.size.x;

        float enemyX = platform.transform.position.x + Random.Range(-platformWidth / 2f, platformWidth / 2f);
        float enemyY = platform.transform.position.y + enemyOffsetY; 
        Vector3 enemyPosition = new Vector3(enemyX, enemyY, 0);

        Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
    }
    }


    void RecyclePlatforms()
    {
        while (activePlatforms.Count > 0 && activePlatforms.Peek().transform.position.x < player.position.x - recycleDistance)
        {
            GameObject oldPlatform = activePlatforms.Dequeue(); 
            Destroy(oldPlatform); 
        }
    }

    void GenerateInitialPlatforms()
    {
        for (int i = 0; i < 5; i++)
        {
            float spawnX = lastSpawnX + Random.Range(minSpawnDistance, maxSpawnDistance);
            float spawnY = Random.Range(minHeight, maxHeight);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

            GameObject platformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            activePlatforms.Enqueue(newPlatform);

            SpawnCoin(newPlatform);
            SpawnEnemy(newPlatform);

            lastSpawnX = spawnX;
        }
    }
}
