using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ¿Ãµø
public class EnemyBehaviorController : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset;

    private Enemy enemy;
    private Coroutine moveEnemyCoroutine;

    private bool isStop;
    public void EnemyBehaviorInit(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.Health.OnDeathEvent += DieEnemy;
    }


    public void ActivateBehavior()
    {
        if (moveEnemyCoroutine != null)
        {
            StopCoroutine(moveEnemyCoroutine);
        }

        moveEnemyCoroutine = StartCoroutine(MoveEnemyCoroutine());
    }

    private IEnumerator MoveEnemyCoroutine()
    {
        enemy.Animation.RunAnimationEvent(true);

        Vector3 arrive = GameManager.Instance.Player.transform.position + moveOffset;

        while (true)
        {
            if (!isStop)
            {
                transform.position = Vector3.MoveTowards(transform.position, arrive, enemy.Data.moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, arrive) <= 0.1f)
                {
                    transform.position = arrive;
                    break;
                }
            }
            yield return null;
        }

        enemy.Animation.RunAnimationEvent(false);
    }

    private void DieEnemy(bool isTrue)
    {
        if (isTrue && moveEnemyCoroutine != null)
        {
            StopCoroutine(moveEnemyCoroutine);
        }
    }

    private void StopEnemyMoving(bool isStop)
    {
        this.isStop = isStop;
    }
}
