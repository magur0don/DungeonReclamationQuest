using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartManager : MonoBehaviour
{
    [SerializeField]
    private Button tapStartButton;

    private void Awake()
    {
        ModalWindowSingletonManager.Instance.CloseModal();
        // サウンドの読み込み
        if (AssetsLoad.Instance.AssetLoaded == false)
        {
            // リソース待ちのモーダルを表示する
            StartCoroutine(ModalWindowSingletonManager.Instance.ShowModal());
            StartCoroutine(AssetsLoad.Instance.LoadSounds(() =>
            {
                SoundManager.Instance.PlayBGM(SoundManager.BGMType.StartGameBGM);
            }));
            StartCoroutine(AssetsLoad.Instance.LoadParticles());
        }
    }

    private void Start()
    {
        if (tapStartButton != null)
        {
            // スタートボタンを押すとMainGameに移行する命令をセットする
            tapStartButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlayUISE(SoundManager.UISEType.Confirm);
                DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameMainSceneName);

            });
        }
    }
}
