using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonReclamationSceneManager : SingletonMonoBehaviour<DungeonReclamationSceneManager>
{
    public const string GameStartSceneName = "GameStart";
    public const string GameMainSceneName = "GameMain";

    private bool isLoadingScene = false;

    /// <summary>
    /// �����ɓ����ꂽ�V�[���ɑJ�ڂ���
    /// </summary>
    /// <param name="sceneName"></param>
    public void SceneTransition(string sceneName)
    {
        if (!isLoadingScene)
        {
            isLoadingScene = true;
            StartCoroutine(StartTransition(sceneName));
        }
    }

    IEnumerator StartTransition(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        isLoadingScene = false;
    }
}
