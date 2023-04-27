using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemiesToSpawn = new List<Enemy>();
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesToSpawn.Count <= 0) return;
        foreach (var enemy in enemiesToSpawn)
        {
            SpawnEnemy(enemyPrefab);
        }
        enemiesToSpawn.Clear();
    }

    public void SpawnEnemy(GameObject enemy)
    {
        Vector2 spriteDimentions = this.GetComponent<SpriteRenderer>().bounds.size;
        float halfSizeX = spriteDimentions.x / 2;
        float halfSizeY = spriteDimentions.y / 2;
        float x = Random.Range(-halfSizeX, halfSizeX);
        float y = Random.Range(-halfSizeY, halfSizeY);
        Vector3 spawnPos = new Vector3(x, y, 0);
        GameObject enemyInstance = Instantiate(enemy, transform.position + spawnPos, Quaternion.identity);
    }
}
