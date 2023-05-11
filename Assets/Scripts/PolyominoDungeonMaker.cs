using System.Linq;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// ダンジョンの生成
    /// </summary>
    public void DungeonMake()
    {
        Debug.Log(MainGameSceneConfigManager.Instance.Level);
        var polyominoDungeons = Instantiate(AssetsLoad.Instance.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            // ダンジョンの穴用の設定を行う
            dungeonHole.sprite = DungeonHoleSprite;
        }
        
        foreach (var dungeonPolyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
        {
            dungeonPolyomino.GetPolyominoCollider.isTrigger = true;
            dungeonPolyomino.GetPolyominoRigidbody2D.isKinematic = true ;
            dungeonPolyomino.IsDungeonPolyomino = true;
        }
    }
}
