using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    //public static CoinManager Instance;
    public UnityEvent onAllCoinsCollected; // Evento da chiamare quando tutte le monete sono raccolte

    public int totalCoins;     // Impostato automaticamente
    public int collectedCoins;

    public DoorController door;  // Riferimento alla porta

    //void Awake()
    //{
    //    Instance = this;
    //}

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        collectedCoins = 0;
    }

    public void CollectCoin()
    {
        collectedCoins++;
        if (collectedCoins >= totalCoins)
        {
            //door.Unlock();
            onAllCoinsCollected?.Invoke(); // Chiama l'evento
        }
    }
}

