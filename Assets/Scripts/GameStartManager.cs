using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    [SerializeField]
    private Button tapStartButton;

    private void Start()
    {
        if (tapStartButton != null)
        {
            // スタートボタンを押すとMainGameに移行する命令をセットする
            tapStartButton.onClick.AddListener(() =>
            {
                DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameMainSceneName);
            });
        }
    }
}
