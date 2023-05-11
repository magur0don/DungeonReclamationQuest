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
                // 1回目は確実にここを通る
                currentCount = rand;
            }
            else
            {
                // 同じrandが2回導き出された
                rand++;
                if (polyominoCount < rand)
                {
                    rand -= enemyCount;
                    if (rand < 0)
                    {
                        // randが0を下回った場合は帰る
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
        // polyominos全部がtrueだったら
        IsBulied = polyominos.All(polyomino => polyomino.IsBuried);
        if (IsBulied)
        {
            Debug.Log("クリア");
        }
    }

}
