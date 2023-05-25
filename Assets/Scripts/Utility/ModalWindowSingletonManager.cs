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
    /// モーダルの下地表示の可否
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
    /// ローディングイメージの表示の可否
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
    /// <param name="isShowBackGround">下地の黒い背景を表示するか</param>
    /// <param name="isShowLoadingImage">ローディング用のイメージを表示するか</param>
    /// <param name="callBackAction">表示が終わった後に何かしたいのであれば実行する</param>
    /// <returns></returns>
    public IEnumerator ShowModal(bool isShow = true, bool isShowBackGround = true, bool isShowLoadingImage = true, UnityAction callBackAction = null)
    {
        // Modalを表示する
        IsModalActive = isShow;
        IsShowBackGround(isShowBackGround);
        IsShowLoadingImage(isShowLoadingImage);
        yield return new WaitUntil(() => IsModalActive);
        yield return new WaitUntil(() => !IsModalActive);
        // Modalを非表示とする
        IsShowBackGround(false);
        IsShowLoadingImage(false);

        if (callBackAction != null)
        {
            callBackAction.Invoke();
        }
    }

    // モーダルを閉じる
    public void CloseModal()
    {
        IsShowBackGround(false);
        IsShowLoadingImage(false);
        IsModalActive = false;
    }


}
