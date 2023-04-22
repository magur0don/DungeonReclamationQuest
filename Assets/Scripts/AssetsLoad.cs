
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

    public Sprite DungeonHoleSprite;
    public Sprite DungeonLidSprite;

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
            var polyominoDungeons = Instantiate(opHandle.Result[level - 1], transform);
            foreach (var polyomino in polyominoDungeons.GetComponentsInChildren<Polyomino>())
            {
                foreach (var poly in polyominoDungeons.GetComponentsInChildren<SpriteRenderer>())
                {
                    poly.sprite = DungeonHoleSprite;
                }
                Polyominos.Add(polyomino);
            }
            AssetLoaded = true;
        }

        // ここでポリオミノをランダムに割り振る
        foreach (var poly in Polyominos)
        {
            var dungeonsLid = Instantiate(poly, PolyominoRoot);

            foreach (var lidRenderer in dungeonsLid.GetComponentsInChildren<SpriteRenderer>())
            {
                lidRenderer.sprite = DungeonLidSprite; 
            }
        }
    }

    void OnDestroy()
    {
        Addressables.Release(opHandle);
    }
}
