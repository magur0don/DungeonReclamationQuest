using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameClearModal : ModalBase
{
    public TextMeshProUGUI GameClearText;

    private void Start()
    {
        GameClearText.text = "GameClear!";
        ButtonModalInitialize(GameClearTransition);
    }

    public void GameClearTransition()
    {
        MainGameSceneConfigManager.Instance.Level++;
        MainGameUmpire.Instance.GetMainGamePlayer.ClearBonus();
        MainGameSceneStateManager.Instance.GameSceneStates = MainGameSceneStateManager.GameSceneState.Init;


        this.gameObject.SetActive(false);
    }
}
