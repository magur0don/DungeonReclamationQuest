using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �^�C�}�[�ƃp�����[�^�[�͕K�{�Ƃ���
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
        // Player�̃X�N���v�g�ɃA�N�Z�X���A�_���[�W��^����
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