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
        // �T�E���h�̓ǂݍ���
        if (AssetsLoad.Instance.AssetLoaded == false)
        {
            // ���\�[�X�҂��̃��[�_����\������
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
            // �X�^�[�g�{�^����������MainGame�Ɉڍs���閽�߂��Z�b�g����
            tapStartButton.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlayUISE(SoundManager.UISEType.Confirm);
                DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameMainSceneName);

            });
        }
    }
}
