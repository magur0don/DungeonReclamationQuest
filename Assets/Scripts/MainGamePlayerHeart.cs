using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamePlayerHeart : MonoBehaviour
{
    public Image heartIcon;
    public Sprite HeartLessIcon;


    private void Awake()
    {
        heartIcon = this.GetComponent<Image>();
    }

    public void DamageChangeHeartIcon()
    {
        heartIcon.sprite = HeartLessIcon;
    }

}
