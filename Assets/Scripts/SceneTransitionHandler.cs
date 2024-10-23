using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    [Header("Loading Screen Settings")]
    [SerializeField] private TextMeshProUGUI _loadingText;

    private float _timerForDots = 0f;
    private int _numberOfDots = 0;
    private const float _timeBetweenDots = 0.5f;

    private void Start()
    {
        StartSceneLoading(GameConstantsRepository.MainMenuSceneOne);
    }

    private void StartSceneLoading(string sceneName)
    {
        StartCoroutine(AsyncSceneLoader(sceneName));
    }

    private IEnumerator AsyncSceneLoader(string sceneName)
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
        sceneLoadingOperation.allowSceneActivation = false;

        while (!sceneLoadingOperation.isDone)
        {
            UpdateDotsInLoadingText();

            if (sceneLoadingOperation.progress >= 0.9f)
            {
                EnableSceneActivation(sceneLoadingOperation);
            }

            yield return null;
        }
    }

    private void UpdateDotsInLoadingText()
    {
        _timerForDots += Time.deltaTime;

        if (_timerForDots >= _timeBetweenDots)
        {
            _numberOfDots = (_numberOfDots + 1) % 4;
            _loadingText.text = "Loading" + new string('.', _numberOfDots);
            _timerForDots = 0f;
        }
    }

    private void EnableSceneActivation(AsyncOperation sceneLoadingOperation)
    {
        sceneLoadingOperation.allowSceneActivation = true;
    }
}