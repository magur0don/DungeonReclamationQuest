using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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

    private Vector3 offset; // �h���b�O���̃I�t�Z�b�g�l

    public bool IsDungeonPolyomino = false;

    public bool IsDragging = false;

    private BoxCollider2D polyominoCollider => GetComponent<BoxCollider2D>();

    public BoxCollider2D GetPolyominoCollider
    {
        get { return polyominoCollider; }
    }
    private Rigidbody2D polyominoRigidbody2D => GetComponent<Rigidbody2D>();

    public Rigidbody2D GetPolyominoRigidbody2D
    {
        get { return polyominoRigidbody2D; }
    }

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

    void OnMouseDown()
    {
        if (IsDungeonPolyomino)
        {
            return;
        }
        // �}�E�X���N���b�N���ꂽ���Ɏ��s����鏈��
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseDrag()
    {
        if (IsDungeonPolyomino)
        {
            return;
        }
        // �}�E�X���h���b�O����Ă���ԂɎ��s����鏈��
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        IsDragging = true;
    }

    private void OnMouseUp()
    {
        IsDragging = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Polyomino>())
        {
            var poly = collision.GetComponent<Polyomino>();
            if (!poly.IsDragging && !poly.IsDungeonPolyomino)
            {
                Debug.Log("���ɂȂ�");
                poly.transform.position = this.transform.localPosition;
            }
        }
    }
}
