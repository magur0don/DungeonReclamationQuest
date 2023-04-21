using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Polyomino : MonoBehaviour
{
    /// <summary>
    /// Poryimino�̌`��z��ŕ\��
    /// �Ⴆ��
    /// 0,0,0
    /// 0,1,0
    /// 1,1,1
    /// ���Ɠʂ�Poryomino�Ƃ���
    /// ���W�͍��ォ�琔���n�߂�
    /// 0,0,0
    /// 0,1,0
    /// 0,0,0
    /// ����1��Polyomino
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
