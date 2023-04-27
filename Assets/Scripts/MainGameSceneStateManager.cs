using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneStateManager : SingletonMonoBehaviour<MainGameSceneStateManager>
{
    public PolyominoDungeonMaker DungeonMaker;
    public PolyominoUserControlLidMaker UserControlLidMaker;
    public AssetsLoad AssetsLoad;
    
    /// <summary>
    /// ゲームシーンのステート
    /// </summary>
    public enum GameSceneState
    {
        Invald,
        Init,
        Start,
        MainGame,
        Result
    }

    public GameSceneState GameSceneStates;

    private void Start()
    {
        isSceneinSingleton = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameSceneStates)
        {
            case GameSceneState.Invald:
                GameSceneStates = GameSceneState.Init;
                break;

            case GameSceneState.Init:
                StartCoroutine(AssetsLoad.LoadDungeons());
                GameSceneStates = GameSceneState.Start;
                break;

            case GameSceneState.Start:
                if (AssetsLoad.AssetLoaded)
                {
                    DungeonMaker.DungeonMake();
                    UserControlLidMaker.UserControlDungeonLidMake();
                    GameSceneStates = GameSceneState.MainGame;
                }
                break;
            case GameSceneState.MainGame:

                break;
            case GameSceneState.Result:

                break;


        }
    }
}
