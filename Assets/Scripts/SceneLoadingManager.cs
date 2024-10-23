using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (IsValidScene(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' is not valid.");
        }
    }

    private bool IsValidScene(string sceneName)
    {
        return sceneName == GameConstantsRepository.TransitionSceneLoading || sceneName == GameConstantsRepository.GameplayScene;
    }

    public void LoadLoadingScreen()
    {
        LoadScene(GameConstantsRepository.TransitionSceneLoading);
    }

    public void LoadGameScene()
    {
        LoadScene(GameConstantsRepository.GameplayScene);
    }
}