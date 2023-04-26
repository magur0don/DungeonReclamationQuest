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

    public void EnemyAttack()
    {
        // Player�̃X�N���v�g�ɃA�N�Z�X���A�_���[�W��^����
    }

    private void Update()
    {
        if (mainGameEnemyTimer.AttackTime < 0)
        {
            EnemyAttack();
        }
    }
}
