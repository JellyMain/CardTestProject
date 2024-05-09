using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class SceneLoader
{
    private readonly ICoroutineRunner coroutineRunner;
    private readonly LoadingScreen loadingScreen;

    
    public SceneLoader(ICoroutineRunner coroutineRunner, LoadingScreen loadingScreen)
    {
        this.coroutineRunner = coroutineRunner;
        this.loadingScreen = loadingScreen;
    }


    public void Load(string sceneName, Action callback = null)
    {
        coroutineRunner.StartCoroutine(LoadScene(sceneName, callback));
    }
    
    
    private IEnumerator LoadScene(string sceneName, Action callback)
    {
        loadingScreen.Show();

        AsyncOperation loadNextScene = SceneManager.LoadSceneAsync(sceneName);

        while (!loadNextScene.isDone)
        {
            yield return null;
        }

        callback?.Invoke();
        
        loadingScreen.Hide();
    }
}
