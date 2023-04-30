using System.Linq;
using UnityEngine;

public class PolyominoUserControlLidMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonLidSprite;

    /// <summary>
    /// User‚ª‘€ì‚·‚éƒ|ƒŠƒIƒ~ƒm‚Ì¶¬
    /// </summary>
    public void UserControlDungeonLidMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);

        polyominoDungeons.GetComponent<Dungeons>().enabled = false;

        polyominoDungeons.name = "UserControlLids";
        // Sprite‚Ìİ’è
        foreach (var userControlPolyominoRenderer in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            userControlPolyominoRenderer.sprite = DungeonLidSprite;
            userControlPolyominoRenderer.sortingOrder = 1;
        }
        foreach (var userControlPolyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
        {
            userControlPolyomino.GetPolyominoCollider.size *= 0.6f;
        }
    }
}
