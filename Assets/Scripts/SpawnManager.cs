using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int wave = 1;    
    [SerializeField] TextMeshProUGUI waveText;
    void Start()
    {
              
    }
      void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyCount);

        if(enemyCount == 0)
        {
            wave +=1;
            SpawnEnemyWave(wave);
            Instantiate(powerupPrefab, GenerateSpawnPosition(),powerupPrefab.transform.rotation); // Her yeni dalgada yeni bir powerup spawn olacak.
        }

        waveText.SetText(wave.ToString());


    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn ; i++)
        {
            Instantiate(enemyPrefab , GenerateSpawnPosition() , enemyPrefab.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float xSpawnPosRange = Random.Range(-spawnRange,spawnRange);
        float zSpawnPosRange = Random.Range(-spawnRange,spawnRange);

        Vector3 randomPos = new Vector3(xSpawnPosRange,0.14f,zSpawnPosRange);
        return randomPos;
    }

    public void StartGame()
    {
        SpawnEnemyWave(wave);
        Instantiate(powerupPrefab, GenerateSpawnPosition(),powerupPrefab.transform.rotation);
    }

  
}
