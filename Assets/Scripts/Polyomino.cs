using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Polyomino : MonoBehaviour
{
    /// <summary>
    /// Poryiminoの形を配列で表現
    /// 例えば
    /// 0,0,0
    /// 0,1,0
    /// 1,1,1
    /// だと凸のPoryominoとする
    /// 座標は左上から数え始める
    /// 0,0,0
    /// 0,1,0
    /// 0,0,0
    /// だと1つのPolyomino
    /// </summary>
    public int[,] PolyominoForm = new int[3, 3]
    {
        { 0, 0, 0 },
        { 0, 0, 0 },
        { 0, 0, 0 }
    };


    private BoxCollider2D polyominoCollider => GetComponent<BoxCollider2D>();

    private void Awake()
    {
        SetPolyominoForm();
    }

    private void SetPolyominoForm()
    {
        foreach (var mino in this.transform.GetComponentsInChildren<SpriteRenderer>())
        {
            PolyominoForm[(int)mino.transform.localPosition.x + 1, (int)mino.transform.localPosition.y + 1] = 1;
        }
    }

    private Vector3 offset; // ドラッグ中のオフセット値

    void OnMouseDown()
    {
        // マウスがクリックされた時に実行される処理
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        // マウスがドラッグされている間に実行される処理
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
