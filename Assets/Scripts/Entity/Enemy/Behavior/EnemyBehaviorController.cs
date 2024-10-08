using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ¿Ãµø
public class EnemyBehaviorController : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset;

    private Enemy enemy;
    private Coroutine moveEnemyCoroutine;

    public void EnemyBehaviorInit(Enemy enemy)
    {
        this.enemy = enemy;
        enemy.Health.OnDeathEvent += StopMoving;
        ActivateBehavior();
    }


    private void ActivateBehavior()
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

        Vector3 arrive = GameManager.Instance.player.transform.position + moveOffset;

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, arrive, enemy.Data.moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, arrive) <= 0.1f)
            {
                transform.position = arrive;
                break;
            }
            yield return null;
        }

        enemy.Animation.RunAnimationEvent(false);
    }

    private void StopMoving(bool isTrue)
    {
        if (isTrue && moveEnemyCoroutine != null)
        {
            StopCoroutine(moveEnemyCoroutine);
        }
    }
}
