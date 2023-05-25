using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverModal : ModalBase
{
    public TextMeshProUGUI GameOverText;

    private void Start()
    {
        GameOverText.text = "GameOver...";

        var returnStartSceneButton = new ButtonAction
        {
            ButtonText = "スタートへ",
            Action = GameOverTransition
        };

        var reStartButton = new ButtonAction
        {
            ButtonText = "続ける",
            Action = NextGameOverTransition
        };

        ButtonModalInitialize(returnStartSceneButton, reStartButton);
    }

    public void GameOverTransition()
    {
        MainGameSceneConfigManager.Instance.Level = 1;
        DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameStartSceneName);
        this.gameObject.SetActive(false);
    }

    public void NextGameOverTransition()
    {
        DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameMainSceneName);
        this.gameObject.SetActive(false);
    }
}
