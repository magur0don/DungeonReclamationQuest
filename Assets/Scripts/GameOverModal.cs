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
        ButtonModalInitialize(GameOverTransition);
    }

    public void GameOverTransition()
    {
        DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameStartSceneName);
        this.gameObject.SetActive(false);
    }
}
