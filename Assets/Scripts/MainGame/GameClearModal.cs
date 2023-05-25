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
        var nextStageButton = new ButtonAction
        {
            ButtonText = "ŽŸ‚Ö",
            Action = GameClearTransition
        };

        ButtonModalInitialize(nextStageButton);
    }

    public void GameClearTransition()
    {
        MainGameSceneConfigManager.Instance.Level++;
        MainGameUmpire.Instance.GetMainGamePlayer.ClearBonus();
        MainGameSceneStateManager.Instance.GameSceneStates = MainGameSceneStateManager.GameSceneState.Init;
        this.gameObject.SetActive(false);
    }
}
