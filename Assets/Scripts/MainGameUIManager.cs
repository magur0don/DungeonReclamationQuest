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

    private void Start()
    {
        playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint;

        for (int i = 0; i < playerHitPointCount; i++)
        {
            var playerHart = Instantiate(PlayerHeartImage, PlayerHeartRoot);
            playerHarts.Add(playerHart.gameObject);
        }
    }

    private void Update()
    {
        if (MainGameSceneStateManager.Instance.GameSceneStates < MainGameSceneStateManager.GameSceneState.Start)
        {
            return;
        }

        if (playerHitPointCount != (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint)
        {
            Debug.Log((int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint);
            playerHarts[playerHitPointCount-1].GetComponent<MainGamePlayerHeart>().DamageChangeHeartIcon();
            playerHitPointCount = (int)MainGameUmpire.Instance.GetMainGamePlayer.MainGamePlayerGetHitPoint;
        }
    }



}
