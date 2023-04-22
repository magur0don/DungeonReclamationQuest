using System.Linq;
using UnityEngine;

public class PolyominoUserControlLidMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonLidSprite;

    /// <summary>
    /// User�����삷��|���I�~�m�̐���
    /// </summary>
    public void UserControlDungeonLidMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);

        polyominoDungeons.GetComponent<Dungeons>().enabled = false;
        // Sprite�̐ݒ�
        foreach (var userControlPolyominoRenderer in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            userControlPolyominoRenderer.sprite = DungeonLidSprite;
            userControlPolyominoRenderer.sortingOrder = 1;
        }

        foreach (var userControlPolyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
        {
            var colliderSize = userControlPolyomino.GetPolyominoCollider.size;
            userControlPolyomino.GetPolyominoCollider.size = colliderSize * 0.9f;
        }
    }
}
