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
            // �X�^�[�g�{�^����������MainGame�Ɉڍs���閽�߂��Z�b�g����
            tapStartButton.onClick.AddListener(() =>
            {
                DungeonReclamationSceneManager.Instance.SceneTransition(DungeonReclamationSceneManager.GameMainSceneName);
            });
        }
    }
}
