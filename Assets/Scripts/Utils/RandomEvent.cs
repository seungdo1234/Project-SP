using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomEvent
{
    private static readonly int totalPercentage = 10000; 

    public static int GetArrRandomResult(int[] percent)
    {
        int random = Random.Range(1, totalPercentage + 1);
        int percentSum = 0;

        for (int i = 0; i < percent.Length; i++)
        {
            percentSum += percent[i];
            if (random <= percentSum)
            {
                return i;
            }
        }

        Debug.LogError("Percent Error");
        return -1;
    }

    public static bool GetBoolRandomResult(int percent)
    {
        int random = Random.Range(0, 10000);

        return random <= percent ? true : false;
    }

    public static int GetRandomOffsetResult(int value, int offsetRange)
    {
        int randomOffset = (value * offsetRange) / 100;
        int offset = Random.Range(0, randomOffset + 1);

        int randomSign = Random.Range(0, 2);
        randomSign = randomSign == 0 ? 1 : -1;

        return value + (offset * randomSign);

    }

}