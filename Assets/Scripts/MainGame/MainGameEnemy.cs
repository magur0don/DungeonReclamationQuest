using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// タイマーとパラメーターは必須とする
[RequireComponent(typeof(MainGameEnemyTimer))]
[RequireComponent(typeof(MainGameEnemyParameterManager))]
public class MainGameEnemy : MonoBehaviour
{
    private MainGameEnemyTimer mainGameEnemyTimer => GetComponent<MainGameEnemyTimer>();
    private MainGameEnemyParameterManager mainGameEnemyParameterManager => GetComponent<MainGameEnemyParameterManager>();

    public Polyomino ParentPolyomino = null;

    public float GetEnemyAttackTime
    {
        get { return mainGameEnemyTimer.AttackTime; }
    }

    private void Awake()
    {
        MainGameUmpire.Instance.SetMainGameEnemy = this;
        ParentPolyomino = transform.parent.GetComponent<Polyomino>();
    }

    public void EnemyAttack()
    {
        // Playerのスクリプトにアクセスし、ダメージを与える
        MainGameUmpire.Instance.GetMainGamePlayer.Damage(mainGameEnemyParameterManager.GetEnemyAttackPoint);
    }

    private void Update()
    {
        // MainGameじゃない場合は帰る
        if (MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame) 
        {
            return;
        }

        if (ParentPolyomino.IsBuried)
        {
            this.gameObject.SetActive(false);
        }

        if (mainGameEnemyTimer.AttackTime < 0)
        {
            EnemyAttack();

            mainGameEnemyTimer.AttackTime = 3.0f;
        }
    }
}
