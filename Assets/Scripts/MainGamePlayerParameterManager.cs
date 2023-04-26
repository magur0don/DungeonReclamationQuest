using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGamePlayerParameterManager : MonoBehaviour
{
    public float HitPoint = 3f;

    public void Damage(int damagePoint)
    {
        if (damagePoint > 0)
        {
            HitPoint -= damagePoint;
        }
    }
}
