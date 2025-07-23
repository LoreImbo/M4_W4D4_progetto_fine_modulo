using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _currentHp = 20;
    [SerializeField] private int _maxHp = 20;
    [SerializeField] private bool _fullHpOnAwake = true;
    [SerializeField] private UnityEvent _onDeath;
    [SerializeField] private UnityEvent<int, int> _onHpChanged;

    public int GetHp() => _currentHp;
    public int GetMaxHp() => _maxHp;

    public void Awake()
    {
        if (_fullHpOnAwake)
        {
            SetHp(_maxHp);
        }
    }

    public void SetHp(int hp)
    {
        int oldHp = _currentHp;
        _currentHp = Mathf.Clamp(hp, 0, _maxHp);
        if (oldHp != _currentHp)
        {
            _onHpChanged?.Invoke(_currentHp, _maxHp);

            if (_currentHp <= 0)
            {
                _onDeath?.Invoke();
                Debug.Log($"Il giocatore {gameObject.name} è morto");
                SceneManager.LoadScene("GameOverMenu"); // Carica la scena del menu di sconfitta
                Time.timeScale = 0f; // Ferma il gioco
            }
        }
    }

    public void TakeDamage(int damage) => SetHp(_currentHp - damage);
    public void Heal(int amount) => SetHp(_currentHp + amount);
}
