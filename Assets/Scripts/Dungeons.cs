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
        var rand = Random.Range(0, this.transform.GetComponentsInChildren<Polyomino>().Count());
        Debug.Log(rand);
        var count = 0;
        foreach (var polyomino in this.transform.GetComponentsInChildren<Polyomino>())
        {
            if (rand == count)
            {
                Instantiate(MainGameEnemy.gameObject, polyomino.transform);
                Debug.Log("ここきてる？");
            }
            count++;
            polyominos.Add(polyomino);
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
