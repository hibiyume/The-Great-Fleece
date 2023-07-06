using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameLevel : MonoBehaviour
{
    [SerializeField] private Image loadingBar;
    [SerializeField] private Image loadingOverlay;

    private void Start()
    {
        StartCoroutine(LoadLevelAsync("Game"));
    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return new WaitForEndOfFrame();
            loadingBar.fillAmount = asyncLoad.progress;
            loadingOverlay.fillAmount = asyncLoad.progress;
        }
    }
}
