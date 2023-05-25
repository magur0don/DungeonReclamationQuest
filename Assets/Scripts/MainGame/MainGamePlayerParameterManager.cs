using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamePlayerParameterManager : MonoBehaviour
{
    public float GetHitPoint
    {
        get { return hitPoint; }
    }

    public float SetHitPoint
    {
        set { hitPoint = value; }
    }

    private float hitPoint = 5;

    private float maxHitPoint;

    public void AddBonusHitPoint() {

        maxHitPoint++;
        hitPoint = maxHitPoint;
    }

    public void ResumeHitPoint() { 
    
    }

    private void Start()
    {
        maxHitPoint = hitPoint;
    }
}
