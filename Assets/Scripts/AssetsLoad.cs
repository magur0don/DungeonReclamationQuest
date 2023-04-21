
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AssetsLoad : MonoBehaviour
{
    public List<string> keys = new List<string>();
    AsyncOperationHandle<IList<GameObject>> opHandle;

    public string Labels;

    public List<Polyomino> Polyominos;

    public bool AssetLoaded = false;

    public int level = 1;

    public Transform PolyominoRoot;

    public IEnumerator Start()
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
            var poly = Instantiate(opHandle.Result[level - 1], transform);
            foreach (var polyomino in poly.GetComponentsInChildren<Polyomino>())
            {
                Polyominos.Add(polyomino);
            }
            AssetLoaded = true;
        }

        // �����Ń|���I�~�m�������_���Ɋ���U��
        foreach (var poly in Polyominos)
        {
            Instantiate(poly, PolyominoRoot);
        }
    }

    void OnDestroy()
    {
        Addressables.Release(opHandle);
    }
}
