using TMPro;
using UnityEngine;

public class GameScoreTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _scoreText;
    [SerializeField] private GameObject _compliteMenu;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _player;

    private int _level;
    private int points = 0;

    private void Start()
    {
        Time.timeScale = 1f;
        _level = PlayerPrefs.GetInt("CurrentLevel", 0);
        UpdateScoreText();
    }

    public void AddPoints(int amount)
    {
        points += amount * ScoreMultiplierManager.Instance.GetScoreMultiplier(); // Умножаем на множитель
        UpdateScoreText();
        
        if (points >= _level * 100)
        {
            _player.GetComponent<CharacterMovementHandler>().enabled = false;
            _gameMenu.SetActive(false);
            _compliteMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void UpdateScoreText()
    {
        if (_scoreText != null)
        {
            for (int i = 0; i < _scoreText.Length; i++)
            {
                _scoreText[i].text = points.ToString("D3") + "/" + _level * 100;
            }
        }
    }
}