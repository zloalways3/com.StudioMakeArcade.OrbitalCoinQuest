using UnityEngine;
using UnityEngine.UI;

public class TimerStateManager : MonoBehaviour
{
    public static TimerStateManager Instance;

    private bool _isTimerRunning;

    [SerializeField] private Image _timerButtonImage; // Image для кнопки
    [SerializeField] private Sprite _onSprite;        // Спрайт для включенного состояния
    [SerializeField] private Sprite _offSprite;       // Спрайт для выключенного состояния

    private void Awake()
    {
        // Убедитесь, что объект не уничтожается при загрузке новой сцены
        
            Instance = this;
            DontDestroyOnLoad(gameObject);


            // Восстанавливаем состояние таймера и кнопки при запуске игры
        if (PlayerPrefs.HasKey("IsTimerRunning"))
        {
            _isTimerRunning = PlayerPrefs.GetInt("IsTimerRunning") == 1;
        }
        else
        {
            _isTimerRunning = true; // По умолчанию таймер включён
        }

        UpdateButtonSprite();
    }

    // Метод для включения/выключения таймера
    public void SetTimerState(bool isRunning)
    {
        _isTimerRunning = isRunning;
        PlayerPrefs.SetInt("IsTimerRunning", isRunning ? 1 : 0); // Сохраняем состояние таймера
        UpdateButtonSprite();
    }

    // Метод для получения текущего состояния таймера
    public bool IsTimerRunning()
    {
        return _isTimerRunning;
    }

    // Метод для обновления спрайта кнопки
    private void UpdateButtonSprite()
    {
        if (_isTimerRunning)
        {
            _timerButtonImage.sprite = _onSprite; // Устанавливаем спрайт "включено"
        }
        else
        {
            _timerButtonImage.sprite = _offSprite; // Устанавливаем спрайт "выключено"
        }
    }

    // Метод, который вызывается при нажатии на кнопку
    public void ToggleTimerState()
    {
        SetTimerState(!_isTimerRunning); // Переключаем состояние таймера
    }
}
