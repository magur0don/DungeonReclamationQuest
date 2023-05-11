using System.Linq;
using UnityEngine;

public class PolyominoDungeonMaker : MonoBehaviour
{
    public Sprite DungeonHoleSprite;

    /// <summary>
    /// �_���W�����̐���
    /// </summary>
    public void DungeonMake()
    {
        // �����ق��łɃ_���W����������ꍇ�͔j������
        if (transform.childCount > 0 && transform.GetChild(0) != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        Debug.Log(MainGameSceneConfigManager.Instance.Level);
        var polyominoDungeons = Instantiate(AssetsLoad.Instance.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);
        foreach (var dungeonHole in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
        {
            // �_���W�����̌��p�̐ݒ���s��
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
