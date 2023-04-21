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

    private void Awake()
    {
        SetPolyominoForm();
    }

    private void SetPolyominoForm()
    {
        foreach (var mino in this.transform.GetComponentsInChildren<SpriteRenderer>())
        {   
            PolyominoForm[(int)mino.transform.localPosition.x+1,(int)mino.transform.localPosition.y + 1] = 1;
        }
    }
}
