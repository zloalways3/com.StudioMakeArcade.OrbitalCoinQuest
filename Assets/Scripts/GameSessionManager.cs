using TMPro;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager Instance;

    private int _numberLives = 100; // Начальное количество жизней 100
    [SerializeField] private TextMeshProUGUI[] _hpText; // Текст для отображения жизней
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _gameMenu;

    private void Awake()
    {
        Instance = this;
        UpdateHpText(); // Обновляем отображение HP при старте
    }

    public void LoseLife(int damage)
    {
        if (!LifeMultiplierManager.Instance.GetLifeMultiplier())
        {
            int effectiveDamage = damage; // Уменьшаем жизни с учётом множителя
            _numberLives -= effectiveDamage; // Уменьшаем жизни на величину урона
            if (_numberLives < 0) _numberLives = 0; // Защита от отрицательных значений
            UpdateHpText(); // Обновляем отображение HP

            if (_numberLives <= 0)
            {
                EndGame();
            }
        }
        
    }

    public void OnScaleTimerScene()
    {
        Time.timeScale = 1f;
    }
    
    public void OffScaleTimerScene()
    {
        Time.timeScale = 0f;
    }

    private void UpdateHpText()
    {
        // Форматируем строку так, чтобы всегда отображалось три цифры (например, 010hp)
        foreach (var TextHpRemained in _hpText)
        {
            TextHpRemained.text = _numberLives.ToString("D3") + "hp";
        }
    }

    private void EndGame()
    {
        _player.GetComponent<CharacterMovementHandler>().enabled = false;
        _loseMenu.SetActive(true);
        _gameMenu.SetActive(false);
        Time.timeScale = 0;
    }
}