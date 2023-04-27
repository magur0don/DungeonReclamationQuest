using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void InitializeUI()
    {
        playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint;

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
    }

    private void Update()
    {
        if (MainGameSceneStateManager.Instance.GameSceneStates != MainGameSceneStateManager.GameSceneState.MainGame)
        {
            return;
        }

        for (int i = 0; i < MainGameUmpire.Instance.GetMainGameEnemies.Count; i++)
        {
            // “G‚ª–„‚Ü‚Á‚½‚ç
            if (!MainGameUmpire.Instance.GetMainGameEnemies[i].gameObject.activeSelf)
            {
                if (enemyAttackGauges[i].gameObject.activeSelf)
                {
                    enemyAttackGauges[i].gameObject.SetActive(false);
                }
                break;
            }
            var normalizedValue = Mathf.InverseLerp(0f, 3f, MainGameUmpire.Instance.GetMainGameEnemies[i].GetEnemyAttackTime);
            enemyAttackGauges[i].fillAmount = normalizedValue;
        }

        if (playerHitPointCount != (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint)
        {
            Debug.Log((int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint);
            playerHarts[playerHitPointCount - 1].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
            playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint;
        }
    }



}
