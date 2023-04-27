using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainGamePlayerParameterManager))]
public class MainGamePlayer : MonoBehaviour
{
    private MainGamePlayerParameterManager mainGamePlayerParameterManager => GetComponent<MainGamePlayerParameterManager>();

    public bool IsDead = false;

    public float MainGamePlayerGetHitPoint
    {
        get { return mainGamePlayerParameterManager.GetHitPoint; }
    }

    public void Damage(float damagePoint)
    {
        var currentHitPoint = mainGamePlayerParameterManager.GetHitPoint;
        if (damagePoint > 0 && currentHitPoint > 0)
        {
            currentHitPoint -= damagePoint;
            mainGamePlayerParameterManager.SetHitPoint = currentHitPoint;
            if (currentHitPoint == 0)
            {
                IsDead = true;
            }
        }
    }

    private void Awake()
    {
        MainGameUmpire.Instance.SetMainGamePlayer = this;
    }

    private void Update()
    {
        if (mainGamePlayerParameterManager.GetHitPoint < 0)
        {
            if (!IsDead)
            {
                IsDead = true;
            }
        }
    }

}
