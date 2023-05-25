using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ModalWindowSingletonManager : SingletonMonoBehaviour<ModalWindowSingletonManager>
{
    [SerializeField]
    private GameObject modalBackground;

    [SerializeField]
    private GameObject loadingImage;

    public bool IsModalActive = false;

    private void Start()
    {
        modalBackground.SetActive(false);
        loadingImage.SetActive(false);
    }

    /// <summary>
    /// ���[�_���̉��n�\���̉�
    /// </summary>
    /// <param name="isVisible"></param>
    public void IsShowBackGround(bool isVisible)
    {
        if (modalBackground != null)
        {
            modalBackground.SetActive(isVisible);
        }
    }

    /// <summary>
    /// ���[�f�B���O�C���[�W�̕\���̉�
    /// </summary>
    /// <param name="isVisible"></param>
    public void IsShowLoadingImage(bool isVisible)
    {
        if (loadingImage != null)
        {
            loadingImage.SetActive(isVisible);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="isShowBackGround">���n�̍����w�i��\�����邩</param>
    /// <param name="isShowLoadingImage">���[�f�B���O�p�̃C���[�W��\�����邩</param>
    /// <param name="callBackAction">�\�����I�������ɉ����������̂ł���Ύ��s����</param>
    /// <returns></returns>
    public IEnumerator ShowModal(bool isShow = true, bool isShowBackGround = true, bool isShowLoadingImage = true, UnityAction callBackAction = null)
    {
        // Modal��\������
        IsModalActive = isShow;
        IsShowBackGround(isShowBackGround);
        IsShowLoadingImage(isShowLoadingImage);
        yield return new WaitUntil(() => IsModalActive);
        yield return new WaitUntil(() => !IsModalActive);
        // Modal���\���Ƃ���
        IsShowBackGround(false);
        IsShowLoadingImage(false);

        if (callBackAction != null)
        {
            callBackAction.Invoke();
        }
    }

    // ���[�_�������
    public void CloseModal()
    {
        IsShowBackGround(false);
        IsShowLoadingImage(false);
        IsModalActive = false;
    }


}
