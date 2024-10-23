using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevelHandler : MonoBehaviour
{
    public static GameLevelHandler Instance;

    [SerializeField] private Button[] _levelButtons;
    private int _totalLevels = 14;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        InitializeLevels();
        UpdateLevelButtons();
    }

    private void InitializeLevels()
    {
        for (int i = 0; i < _totalLevels; i++)
        {
            if (!PlayerPrefs.HasKey("Level" + i))
            {
                PlayerPrefs.SetInt("Level" + i, i == 0 ? 1 : 0);
            }
        }

        PlayerPrefs.Save();
    }

    public void WinLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("Level" + levelIndex, 1);
        PlayerPrefs.Save();
    }

    private void UpdateLevelButtons()
    {
        for (int i = 0; i < _totalLevels; i++)
        {
            if (i == 0 || PlayerPrefs.GetInt("Level" + (i), 0) == 1)
            {
                _levelButtons[i].interactable = true;
                _levelButtons[i].image.color = Color.white;
            }
            else
            {
                _levelButtons[i].interactable = false;
                _levelButtons[i].image.color = new Color(1, 1, 1, 0.78f);
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("CurrentLevel", levelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(GameConstantsRepository.GameplayScene);
    }
}