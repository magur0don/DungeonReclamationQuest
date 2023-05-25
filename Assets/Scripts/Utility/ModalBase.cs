using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ModalBase : MonoBehaviour
{
    /// <summary>
    /// 1つ目のボタン
    /// </summary>
    [SerializeField]
    private Button primaryButton;

    /// <summary>
    /// 2つ目のボタン
    /// </summary>
    [SerializeField]
    private Button secondaryButton;

    public class ButtonAction
    {
        public UnityAction Action = null;
        public string ButtonText = string.Empty;
    }

    public virtual void ShowButtonModal()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void CloseButtonModal()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void ButtonModalInitialize(ButtonAction primaryButtonAction, ButtonAction secondaryButtonAction = null)
    {
        primaryButton.onClick.RemoveAllListeners();
        secondaryButton.onClick.RemoveAllListeners();

        if (primaryButton != null)
        {
            primaryButton.onClick.AddListener(() => primaryButtonAction.Action.Invoke());
            primaryButton.GetComponentInChildren<TextMeshProUGUI>().text = primaryButtonAction.ButtonText;
        }

        if (secondaryButtonAction == null)
        {
            secondaryButton.gameObject.SetActive(false);
        }

        if (secondaryButton != null && secondaryButtonAction != null)
        {
            secondaryButton.onClick.AddListener(() => secondaryButtonAction.Action.Invoke());
            secondaryButton.GetComponentInChildren<TextMeshProUGUI>().text = secondaryButtonAction.ButtonText;
        }

    }

}
