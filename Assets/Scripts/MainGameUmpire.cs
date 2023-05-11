using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUmpire : SingletonMonoBehaviour<MainGameUmpire>
{
    [SerializeField]
    private MainGamePlayer mainGamePlayer;
    public MainGamePlayer SetMainGamePlayer
    {
        set { mainGamePlayer = value; }
    }
    public MainGamePlayer GetMainGamePlayer
    {
        get { return mainGamePlayer; }
    }

    // 複数のエネミーに対応
    private List<MainGameEnemy> mainGameEnemies = new List<MainGameEnemy>();
    public MainGameEnemy SetMainGameEnemy
    {
        set { mainGameEnemies.Add(value); }
    }

    public List<MainGameEnemy> GetMainGameEnemies
    {
        get { return mainGameEnemies; }
    }

    public bool IsReady = false;


    private void Start()
    {
        isSceneinSingleton = true;
        MainGameSceneStateManager.Instance.MainGameUmpire = this;
    }

    private void Update()
    {


        if (IsReady)
        {
            return;
        }

        if (IsReady == false && GetMainGamePlayer != null && mainGameEnemies.Count > 0)
        {
            IsReady = true;
        }
    }

}
