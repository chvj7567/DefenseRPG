using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyScene : BaseScene
{
    CanvasGroup _canvasGroup;
    UI_Loading _loadingUI;
    UI_Start _startUI;
    float _LoadingPercent = 0.1f;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scenes.Lobby;
        _startUI = MainManager.UI.ShowUI("StartUI", Define.UI.Start).GetComponent<UI_Start>();
        _startUI.onStartAction -= LoadGameScene;
        _startUI.onStartAction += LoadGameScene;
    }

    void LoadGameScene()
    {
        _canvasGroup = MainManager.UI.ShowUI("LoadingUI", Define.UI.Loading).GetComponent<CanvasGroup>();
        _loadingUI = _canvasGroup.GetComponent<UI_Loading>();

        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        StartCoroutine(Loading());
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == MainManager.Scene.CurrentScene.name)
        {
            StartCoroutine(Fade(false));
        }
    }

    IEnumerator Loading()
    {
        yield return StartCoroutine(Fade(true));
        AsyncOperation async = MainManager.Scene.LoadScene(Define.Scenes.Game);
        async.allowSceneActivation = false;

        float time = 0f;

        while (!async.isDone)
        {
            yield return null;
            if (async.progress < _LoadingPercent)
            {
                _loadingUI.Bar.fillAmount = async.progress;
            }
            else
            {
                time += Time.unscaledDeltaTime;
                _loadingUI.Bar.fillAmount = Mathf.Lerp(_LoadingPercent, 1f, time);
                
                if (_loadingUI.Bar.fillAmount >= 1f)
                {
                    async.allowSceneActivation = true;
                    yield break;
                }
            }    
        }
    }
    IEnumerator Fade(bool isFadeIn)
    {
        float time = 0f;

        while (time <= 1f)
        {
            time += Time.unscaledDeltaTime;

            if (isFadeIn)
                _canvasGroup.alpha = Mathf.Lerp(0f, 1f, time);
            else
                _canvasGroup.alpha = Mathf.Lerp(1f, 0f, time);

            yield return null;
        }

        if (!isFadeIn)
            _canvasGroup.gameObject.SetActive(false);
    }

    public override void Clear()
    {

    }
}
