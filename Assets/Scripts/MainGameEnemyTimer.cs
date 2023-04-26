using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameEnemyTimer : MonoBehaviour
{
    public float AttackTime = 3.0f;

    // Update is called once per frame
    void Update()
    {
        AttackTime -= Time.deltaTime;
    }
}
