using UnityEngine;
using UnityEngine.UI;

public class ScoreMultiplierManager : MonoBehaviour
{
    public static ScoreMultiplierManager Instance;

    private bool _isMultiplierActive;
    private const int Multiplier = 10;

    [SerializeField] private Image _multiplierButtonImage; // Image для кнопки
    [SerializeField] private Sprite _onSprite; // Спрайт для включенного состояния
    [SerializeField] private Sprite _offSprite; // Спрайт для выключенного состояния

    private void Awake()
    {
        Instance = this;
            DontDestroyOnLoad(gameObject);

            // Восстанавливаем состояние множителя из PlayerPrefs
        if (PlayerPrefs.HasKey("IsMultiplierActive"))
        {
            _isMultiplierActive = PlayerPrefs.GetInt("IsMultiplierActive") == 1;
        }
        else
        {
            _isMultiplierActive = false; // По умолчанию множитель выключен
        }

        UpdateButtonSprite(); // Обновляем спрайт кнопки при старте
    }

    private void Start()
    {
        UpdateButtonSprite(); // Обновляем спрайт кнопки
    }

    // Метод для переключения состояния множителя
    public void ToggleMultiplierState()
    {
        _isMultiplierActive = !_isMultiplierActive;
        PlayerPrefs.SetInt("IsMultiplierActive", _isMultiplierActive ? 1 : 0); // Сохраняем состояние
        UpdateButtonSprite();
    }

    // Метод для получения текущего состояния множителя
    public bool IsMultiplierActive()
    {
        return _isMultiplierActive;
    }

    // Метод для обновления спрайта кнопки
    private void UpdateButtonSprite()
    {
        if (_multiplierButtonImage != null)
        {
            _multiplierButtonImage.sprite = _isMultiplierActive ? _onSprite : _offSprite;
        }
    }

    // Метод для получения множителя
    public int GetScoreMultiplier()
    {
        return _isMultiplierActive ? Multiplier : 1;
    }
}
