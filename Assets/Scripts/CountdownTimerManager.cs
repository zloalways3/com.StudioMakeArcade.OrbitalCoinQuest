using UnityEngine;
using TMPro; // Для TextMeshPro

public class CountdownTimerManager : MonoBehaviour
{
    [SerializeField] private GameObject _complite;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private TextMeshProUGUI[] _timerText;

    private float _timeRemaining = 60f;
    private bool _isTimerRunning = false;

    private void Start()
    {
        // Получаем текущее состояние таймера из другого класса
        _isTimerRunning = TimerStateManager.Instance.IsTimerRunning();

        UpdateTimerText();
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                _timeRemaining = 0;
                _isTimerRunning = false;
                _complite.SetActive(true);
                _gameObject.SetActive(false);
                Time.timeScale = 0f;
                TimerStateManager.Instance.SetTimerState(false); // Обновляем состояние таймера
            }
        }
        else
        {
            foreach (var TimerTextRemained in _timerText)
            {
                TimerTextRemained.text = "Off Timer";
            }
        }
    }

    private void UpdateTimerText()
    {
        foreach (var TimerTextRemained in _timerText)
        {
            TimerTextRemained.text = Mathf.Ceil(_timeRemaining).ToString() + " sec";
        }
        
    }
}