using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneConfigManager : SingletonMonoBehaviour<MainGameSceneConfigManager>
{
    public int Level = 1;

    private void Start()
    {
        isSceneinSingleton = true;
    }
}
