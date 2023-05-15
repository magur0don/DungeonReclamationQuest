using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUIManager : MonoBehaviour
{
    public Image PlayerHeartImage;

    private List<GameObject> playerHarts = new List<GameObject>();

    public RectTransform PlayerHeartRoot;

    private int playerHitPointCount;

    public Image EnemyAttackGauge;

    private List<Image> enemyAttackGauges = new List<Image>();

    /// <summary>
    /// �Q�[���I�[�o�[�p��UI
    /// </summary>
    [SerializeField]
    private GameObject gameOverModal;

    private GameObject gameOverModalInstance = null;

    /// <summary>
    /// �Q�[���N���A�p��UI
    /// </summary>
    [SerializeField]
    private GameObject gameClearModal;

    private GameObject gameClearModalInstance = null;

    [SerializeField]
    private TextMeshProUGUI levelText;



    public void InitializeUI()
    {
        playerHarts.Clear();
        enemyAttackGauges.Clear();
        // ���łɐ��܂�Ă���ꍇ�͍폜
        if (PlayerHeartRoot.childCount > 0)
        {
            for (int i = 0; i < PlayerHeartRoot.childCount; i++)
            {
               Destroy(PlayerHeartRoot.GetChild(i).gameObject);
            }
        }

        playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;

        for (int i = 0; i < playerHitPointCount; i++)
        {
            var playerHart = Instantiate(PlayerHeartImage, PlayerHeartRoot);
            playerHarts.Add(playerHart.gameObject);
        }
        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            var enemyGauge = Instantiate(EnemyAttackGauge.gameObject, this.transform);
            enemyGauge.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, MainGameUmpire.Instance.GetMainGameEnemies[i].transform.position);
            enemyAttackGauges.Add(enemyGauge.GetComponent<Image>());
        }

        levelText.text = $"Level:{MainGameSceneConfigManager.Instance.Level}";

    }

    /// <summary>
    /// �Q�[���I�o�[�p�̃��[�_����\������
    /// </summary>
    public void ShowGameOverModal(Transform modalCanvas)
    {
        if (gameOverModal != null && gameOverModalInstance == null)
        {
            gameOverModalInstance = Instantiate(gameOverModal, modalCanvas);
            gameOverModalInstance.SetActive(true);
        }

        if (gameOverModalInstance = null)
        {
            gameOverModalInstance.SetActive(true);
        }
    }


    /// <summary>
    /// �Q�[���N���A�p�̃��[�_����\������
    /// </summary>
    public void ShowGameClearModal(Transform modalCanvas)
    {
        if (gameClearModal != null && gameClearModalInstance == null)
        {
            gameClearModalInstance = Instantiate(gameClearModal, modalCanvas);
            gameClearModalInstance.SetActive(true);
        }
        if (gameClearModalInstance = null)
        {
            gameClearModalInstance.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame)
        {
            return;
        }

        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            // �G�����܂�����
            if (!MainGameUmpire.Instance.GetMainGameEnemies[i].gameObject.activeSelf)
            {
                if (enemyAttackGauges[i].gameObject.activeSelf)
                {
                    enemyAttackGauges[i].gameObject.SetActive(false);
                }
            }

            if (enemyAttackGauges[i].gameObject.activeSelf)
            {
                var normalizedValue = Mathf.InverseLerp(0f, 3f, MainGameUmpire.Instance.GetMainGameEnemies[i].GetEnemyAttackTime);
                enemyAttackGauges[i].fillAmount = normalizedValue;
            }
        }
        // HitPoint5��Damage������������PlayerHP��3�������ꍇ
        if (playerHitPointCount != (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint)
        {
            // 2������
            var countDiff = playerHitPointCount - (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
            var count = 0;
            for (int i = 0; i < countDiff; i++)
            {
                count++;
                if (playerHarts[playerHitPointCount - count] != null)
                {
                    playerHarts[playerHitPointCount - count].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
                }
            }
            playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.PlayerGetHitPoint;
        }
    }



}
