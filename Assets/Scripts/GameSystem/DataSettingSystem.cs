using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSettingSystem : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(InitDataCoroutine());
    }

    private IEnumerator InitDataCoroutine()
    {
        yield return new WaitUntil(() => GameManager.Instance.Player != null);
        GameManager.Instance.Player.PlayerInit();
        GameManager.Instance.GameStart();
    }

}
