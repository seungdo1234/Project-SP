using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVDataLoadSystem
{
    private readonly string dataPath = "Data/SampleMonster";

    public List<EnemyStatData> LoadCSVEnemyData()
    {
        List<EnemyStatData> enemyDataList = new List<EnemyStatData>();
        List<Dictionary<string, object>> readData = CSVReader.Read(dataPath);

        for (int i  = 0; i <  readData.Count - 1; i++)
        {
            try
            {
                EnemyStatData enemyData = new EnemyStatData();

                enemyData.Name = readData[i]["Name"] as string;
                enemyData.Grade = ParseGradeType(readData[i]["Grade"] as string);
                enemyData.Speed = Convert.ToSingle(readData[i]["Speed"]);
                enemyData.Speed += 1.5f;
                enemyData.Health = Convert.ToSingle(readData[i]["Health"]);

                enemyDataList.Add(enemyData);
            }
            catch (Exception e)
            {
                Debug.LogError($"{e} => CSV Parsing Error");
            }
        }


        return enemyDataList;
    }

    private E_GradeType ParseGradeType(string grade)
    {
        switch (grade)
        {
            case "일반": return E_GradeType.Common;
            case "레어": return E_GradeType.Rare;
            case "매직": return E_GradeType.Magic;
            case "전설": return E_GradeType.Legendary;
            case "영웅": return E_GradeType.Hero;
            default: throw new ArgumentException($"Unknown grade type: {grade}");
        }
    }
}
