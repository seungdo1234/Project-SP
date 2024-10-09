using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnManager : MonoBehaviour
{
    [Header("# Enemy Info")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private RuntimeAnimatorController[] enemyAnimators;
    [SerializeField] private List<EnemyStatData> enemyDataList = new List<EnemyStatData>();

    [Header("# Spawn Info")]
    [SerializeField] private Transform spawnPoint;

    private int enemyIdx = 0;

    private void Awake()
    {
        enemyDataList = new CSVDataLoadSystem().LoadCSVEnemyData();
    }
    private void Start()
    {
        GameManager.Instance.EnemySpawn = this;
    }
    public void TryEnemySpawn()
    {
        enemyPrefab.transform.position = spawnPoint.position;
        enemyPrefab.gameObject.SetActive(true);
        enemyPrefab.EnemyInit(enemyAnimators[enemyIdx], enemyDataList[enemyIdx]);

        enemyIdx = (enemyIdx + 1) % enemyAnimators.Length;
    }
}
