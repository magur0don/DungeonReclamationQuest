using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dungeons : MonoBehaviour
{
    private List<Polyomino> polyominos = new List<Polyomino>();

    public bool IsBulied = false;

    public MainGameEnemy MainGameEnemy;

    private void Start()
    {
        MainGameSceneStateManager.Instance.Dungeons = this;

        var polyominoCount = this.transform.GetComponentsInChildren<Polyomino>().Count();
        var enemyCount = Random.Range(1, polyominoCount);
        
        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            polyominos.Add(polyomino);
        }

        var currentCount = -1;
        for (int i = 0; i < enemyCount; i++)
        {
            // 3
            var rand = Random.Range(0, polyominoCount);
            if (currentCount != rand)
            {
                // 1��ڂ͊m���ɂ�����ʂ�
                currentCount = rand;
            }
            else
            {
                // ����rand��2�񓱂��o���ꂽ
                rand++;
                if (polyominoCount < rand)
                {
                    rand -= enemyCount;
                    if (rand < 0)
                    {
                        // rand��0����������ꍇ�͋A��
                        return;
                    }
                }
            }
            var count = 0;
            foreach (var polyomino in polyominos)
            {
                if (rand == count)
                {
                    var enemy = Instantiate(MainGameEnemy.gameObject, polyomino.transform);

                    foreach (var squarePos in polyomino.GetComponentsInChildren<SpriteRenderer>())
                    {
                        enemy.transform.position = squarePos.transform.position;
                    }
                }
                count++;
            }
        }
    }

    private void Update()
    {
        // polyominos�S����true��������
        IsBulied = polyominos.All(polyomino => polyomino.IsBuried);
        if (IsBulied)
        {
            Debug.Log("�N���A");
        }
    }

}
