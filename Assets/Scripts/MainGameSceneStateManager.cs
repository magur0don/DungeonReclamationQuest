using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneStateManager : SingletonMonoBehaviour<MainGameSceneStateManager>
{
    public PolyominoDungeonMaker DungeonMaker;
    public PolyominoUserControlLidMaker UserControlLidMaker;
    public MainGameUIManager MainGameUIManager;
    public MainGameUmpire MainGameUmpire;

    public Dungeons Dungeons;

    /// <summary>
    /// �Q�[���V�[���̃X�e�[�g
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

    public override void Awake()
    {
        isSceneinSingleton = true;
        base.Awake();
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

                // �ŏ��Ƀ��[�_�����̂���Ă���
                ModalWindowSingletonManager.Instance.CloseModal();
                MainGameUmpire.Instance.IsReady = false;
                MainGameUmpire.Instance.GetMainGameEnemies.Clear();
                // ���\�[�X�̓ǂݍ���
                if (AssetsLoad.Instance.AssetLoaded == false)
                {
                    StartCoroutine(AssetsLoad.Instance.LoadDungeons());
                    // ���\�[�X�҂��̃��[�_����\������
                    StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal());
                }

                GameSceneStates = GameSceneState.Ready;
                break;
            case GameSceneState.Ready:

                if (AssetsLoad.Instance.AssetLoaded)
                {
                    DungeonMaker.DungeonMake();
                    UserControlLidMaker.UserControlDungeonLidMake();
                    GameSceneStates = GameSceneState.Start;
                }
                break;
            case GameSceneState.Start:
                if (MainGameUmpire.IsReady)
                {
                    // UI������������
                    MainGameUIManager.InitializeUI();
                    ModalWindowSingletonManager.Instance.CloseModal();
                    GameSceneStates = GameSceneState.MainGame;
                }
                break;
            case GameSceneState.MainGame:
                if (MainGameUmpire.Instance.GetMainGamePlayer.IsDead)
                {
                    StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal(isShowLoadingImage: false));
                    MainGameUIManager.ShowGameOverModal(ModalWindowSingletonManager.Instance.transform);
                    GameSceneStates = GameSceneState.Result;
                }
                if (Dungeons.IsBulied) {
                    StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal(isShowLoadingImage: false));
                    MainGameUIManager.ShowGameClearModal(ModalWindowSingletonManager.Instance.transform);
                    GameSceneStates = GameSceneState.Result;
                }

                break;
            case GameSceneState.Result:

                break;
        }
    }
}
