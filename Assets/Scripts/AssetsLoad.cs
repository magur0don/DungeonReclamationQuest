
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsLoad : MonoBehaviour
{
    public List<string> keys = new List<string>();
    AsyncOperationHandle<IList<GameObject>> opHandle;

    public IEnumerator Start()
    {
        opHandle = Addressables.LoadAssetsAsync<GameObject>
            (keys,
                obj =>
                {
                    //Gets called for every loaded asset
                    Debug.Log(obj.name);
                },
                Addressables.MergeMode.Union
            );

        yield return opHandle;

        if (opHandle.Status == AsyncOperationStatus.Succeeded)
        {
            foreach (var obj in opHandle.Result)
            {
                Instantiate(obj, transform);
            }
        }
    }

    void OnDestroy()
    {
        Addressables.Release(opHandle);
    }
}
