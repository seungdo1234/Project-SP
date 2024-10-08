using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : DontDestroySingleton<GameManager>
{
    [field: SerializeField] public Player Player { get; set; }
    [field:SerializeField]public EnemySpawnManager EnemySpawn { get; set; }

    public void GameStart()
    {

        EnemySpawn.TryEnemySpawn();
    }
}
