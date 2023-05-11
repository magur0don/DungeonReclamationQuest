
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsLoad : SingletonMonoBehaviour<AssetsLoad>
{
    public List<string> keys = new List<string>();
    AsyncOperationHandle<IList<GameObject>> opHandle;

    public string Labels;

    public List<GameObject> LoadedDungeons;

    public bool AssetLoaded = false;

    public IEnumerator LoadDungeons()
    {
        opHandle = Addressables.LoadAssetsAsync<GameObject>
            (Labels,
                //obj =>
                //{
                //    //Gets called for every loaded asset
                //    Debug.Log(obj.name);
                //},
                //Addressables.MergeMode.Union
                null
            );

        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            for (int i = 0; i < opHandle.Result.Count; i++)
            {
                LoadedDungeons.Add(opHandle.Result[i]);
            }
            AssetLoaded = true;
        }
    }

    void OnDestroy()
    {
        if (opHandle.IsValid()) {
            Addressables.Release(opHandle);
    }
    }
}
