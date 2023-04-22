using System.Linq;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// ƒ_ƒ“ƒWƒ‡ƒ“‚Ì¶¬
    /// </summary>
    public void DungeonMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            dungeonHole.sprite = DungeonHoleSprite;
        }
    }
}
