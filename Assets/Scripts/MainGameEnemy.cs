using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// タイマーとパラメーターは必須とする
[RequireComponent(typeof(MainGameEnemyTimer))]
[RequireComponent(typeof(MainGameEnemyParameterManager))]
public class MainGameEnemy : MonoBehaviour
{
    private MainGameEnemyTimer mainGameEnemyTimer => GetComponent<MainGameEnemyTimer>();
    private MainGameEnemyParameterManager mainGameEnemyParameterManager => GetComponent<MainGameEnemyParameterManager>();

    public void EnemyAttack()
    {
        // Playerのスクリプトにアクセスし、ダメージを与える
    }

    private void Update()
    {
        if (mainGameEnemyTimer.AttackTime < 0)
        {
            EnemyAttack();
        }
    }
}
