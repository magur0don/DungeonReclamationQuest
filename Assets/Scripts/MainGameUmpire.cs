using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUmpire : SingletonMonoBehaviour<MainGameUmpire>
{

    private MainGamePlayer mainGamePlayer;
    public MainGamePlayer SetMainGamePlayer
    {
        set { mainGamePlayer = value; }
    }
    public MainGamePlayer GetMainGamePlayer
    {
        get { return mainGamePlayer; }
    }

    private MainGameEnemy mainGameEnemy;
    public MainGameEnemy SetMainGameEnemy
    {
        set { mainGameEnemy = value; }
    }
    public MainGameEnemy GetMainGameEnemy
    {
        get { return mainGameEnemy; }
    }

    private void Start()
    {
        isSceneinSingleton = true;
    }

}
