using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float _timeLimit = 300f;

    [SerializeField] private TextMeshProUGUI _timerText; 

    [SerializeField] private LifeController _playerHp;
    private float _currentTime;

    void Start()
    {
        _currentTime = _timeLimit;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_timerText != null)
        {
            _timerText.text = "Timer: " + Mathf.Ceil(_currentTime).ToString();
        }
        if (_currentTime <= 0f)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
        Debug.Log("Tempo scaduto!");

        if (_playerHp != null)
        {
            _playerHp.TakeDamage(_playerHp.GetMaxHp());
            Time.timeScale = 0f; // Ferma il gioco
        }
    }
}
