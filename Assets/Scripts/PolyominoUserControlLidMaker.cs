using System.Linq;
using UnityEngine;

public class PolyominoUserControlLidMaker : MonoBehaviour
{
    public Sprite DungeonLidSprite;

    /// <summary>
    /// User�����삷��|���I�~�m�̐���
    /// </summary>
    public void UserControlDungeonLidMake()
    {
        // �����ق��łɃ_���W����������ꍇ�͔j������
        if (transform.childCount > 0 && transform.GetChild(0) != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        var polyominoDungeons = Instantiate(AssetsLoad.Instance.LoadedDungeons[MainGameSceneConfigManager.Instance.Level - 1], transform);

        polyominoDungeons.GetComponent<Dungeons>().enabled = false;

        polyominoDungeons.name = "UserControlLids";
        // Sprite�̐ݒ�
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
