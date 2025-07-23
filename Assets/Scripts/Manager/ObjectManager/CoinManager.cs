using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    //public static CoinManager Instance;
    public UnityEvent onAllCoinsCollected; // Evento da chiamare quando tutte le monete sono raccolte

    private int totalCoins;     // Impostato automaticamente
    public int collectedCoins;

    //void Awake()
    //{
    //    Instance = this;
    //}

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log($"Monete totali: {totalCoins}");
        collectedCoins = 0;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        Debug.Log($"Monete raccolte: {collectedCoins}");
        if (collectedCoins >= totalCoins)
        {
            Debug.Log("Tutte le monete sono state raccolte!");
            //door.Unlock();
            onAllCoinsCollected?.Invoke(); // Chiama l'evento
        }
    }
}

