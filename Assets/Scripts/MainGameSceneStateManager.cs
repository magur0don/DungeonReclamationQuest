using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneStateManager : SingletonMonoBehaviour<MainGameSceneStateManager>
{
    public PolyominoDungeonMaker DungeonMaker;
    public PolyominoUserControlLidMaker UserControlLidMaker;
    public AssetsLoad AssetsLoad;
    public MainGameUIManager MainGameUIManager;
    public MainGameUmpire MainGameUmpire;

    /// <summary>
    /// ゲームシーンのステート
    /// </summary>
    public enum GameSceneState
    {
        Invald,
        Init,
        Ready,
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
                // リソースの読み込み
                StartCoroutine(AssetsLoad.LoadDungeons());

                // リソース待ちのモーダルを表示する
                StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal());

                GameSceneStates = GameSceneState.Ready;
                break;
            case GameSceneState.Ready:

                if (AssetsLoad.AssetLoaded)
                {
                    DungeonMaker.DungeonMake();
                    UserControlLidMaker.UserControlDungeonLidMake();
                    GameSceneStates = GameSceneState.Start;
                }
                break;
            case GameSceneState.Start:
                if (MainGameUmpire.IsReady)
                {
                    // UIを初期化する
                    MainGameUIManager.InitializeUI();
                    ModalWindowSingletonManager.Instance.CloseModal();
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
