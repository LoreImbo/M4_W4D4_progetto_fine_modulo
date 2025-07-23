using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAllCoinsCollected; // Evento da chiamare quando tutte le monete sono raccolte

    private int _totalCoins; 
    private int _collectedCoins;

    void Start()
    {
        _totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log($"Monete totali da raccogliere per sbloccare le scale: {_totalCoins}");
        _collectedCoins = 0;
    }

    public void CollectCoin()
    {
        _collectedCoins++;
        Debug.Log($"Monete raccolte: {_collectedCoins}");
        if (_collectedCoins >= _totalCoins)
        {
            Debug.Log("Tutte le monete sono state raccolte!");
           
            _onAllCoinsCollected?.Invoke(); // Chiama l'evento
        }
    }
}

