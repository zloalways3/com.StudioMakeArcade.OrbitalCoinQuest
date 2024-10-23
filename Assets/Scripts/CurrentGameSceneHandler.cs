using UnityEngine;

public class CurrentGameSceneHandler : MonoBehaviour
{
    private int _currentLevel;

    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
    }

    public void WinGame()
    {
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel + 1);
        PlayerPrefs.Save();
        GameLevelHandler gameLevelHandler = FindObjectOfType<GameLevelHandler>();
        gameLevelHandler.WinLevel(_currentLevel);
    }
}