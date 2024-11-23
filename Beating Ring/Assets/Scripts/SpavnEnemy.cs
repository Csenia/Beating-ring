using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpavnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _numberOfEnemies = 10; 
    [SerializeField] private float _spawnRadius = 10f;
    [SerializeField] private float _spawnInterval = 1f;

    private int _enemiesSpawned = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, _spawnInterval);
    }

    void SpawnEnemy()
    {
        if (_enemyPrefab == null)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }

        if (_enemiesSpawned >= _numberOfEnemies)
        {
            CancelInvoke("SpawnEnemy");
            return;
        }

        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        _enemiesSpawned++;
    }
}
