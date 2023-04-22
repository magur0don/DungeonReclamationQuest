using System.Linq;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public AssetsLoad AssetsLoad;
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// �_���W�����̐���
    /// </summary>
    public void DungeonMake()
    {
        var polyominoDungeons = Instantiate(AssetsLoad.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            // �_���W�����̌��p�̐ݒ���s��
            dungeonHole.sprite = DungeonHoleSprite;
        }
    }
}
