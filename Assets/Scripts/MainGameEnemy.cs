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

    public float GetEnemyAttackTime
    {
        get { return mainGameEnemyTimer.AttackTime; }
    }

    private void Awake()
    {
        MainGameUmpire.Instance.SetMainGameEnemy = this;
    }

    public void EnemyAttack()
    {
        // Playerのスクリプトにアクセスし、ダメージを与える
        MainGameUmpire.Instance.GetMainGamePlayer.Damage(mainGameEnemyParameterManager.GetEnemyAttackPoint);
    }

    private void Update()
    {
        if (mainGameEnemyTimer.AttackTime < 0)
        {
            EnemyAttack();

            mainGameEnemyTimer.AttackTime = 3.0f;
        }
    }
}
