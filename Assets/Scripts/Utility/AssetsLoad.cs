
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Linq;
using UnityEngine.Events;

public class AssetsLoad : SingletonMonoBehaviour<AssetsLoad>
{
    public List<string> keys = new List<string>();
    AsyncOperationHandle<IList<GameObject>> opHandle;

    AsyncOperationHandle<IList<AudioClip>> soundHandle;
    public string Labels;

    public List<GameObject> LoadedDungeons=new List<GameObject>();

    public bool AssetLoaded = false;

    public IEnumerator LoadDungeons()
    {
        AssetLoaded = false;
        opHandle = Addressables.LoadAssetsAsync<GameObject>
            ("Dungeons",
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


    public IEnumerator LoadSounds(UnityAction act = null)
    {
        AssetLoaded = false;
        IEnumerable soundLabels = new object[] {
            "BGM",
            "UISE",
            "MainGameSE"
        };
        soundHandle = Addressables.LoadAssetsAsync<AudioClip>
            (soundLabels,
                null,Addressables.MergeMode.Union
            );

        yield return soundHandle;

        var bgmLoadHandle = Addressables.LoadAssetsAsync<AudioClip>("BGM", null);
        yield return bgmLoadHandle;
        SoundManager.Instance.SetBGMClips(bgmLoadHandle.Result.ToArray());
        var uiSELoadHandle = Addressables.LoadAssetsAsync<AudioClip>("UISE", null);
        yield return uiSELoadHandle;
        SoundManager.Instance.SetUISEClips(uiSELoadHandle.Result.ToArray());

        var mainGameSeLoadHandle = Addressables.LoadAssetsAsync<AudioClip>("MainGameSE", null);
        yield return mainGameSeLoadHandle;
        SoundManager.Instance.SetMainGameSEClips(mainGameSeLoadHandle.Result.ToArray());

        if (soundHandle.Status == AsyncOperationStatus.Succeeded)
        {
            AssetLoaded = true;
            act?.Invoke();
        }
    }


    void OnDestroy()
    {
        if (opHandle.IsValid())
        {
            Addressables.Release(opHandle);
        }
        if (soundHandle.IsValid())
        {
            Addressables.Release(soundHandle);
        }
    }
}
