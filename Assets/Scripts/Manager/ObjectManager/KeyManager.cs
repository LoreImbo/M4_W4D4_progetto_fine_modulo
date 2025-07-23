using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    //public static CoinManager Instance;
    public UnityEvent onAllKeysCollected; // Evento da chiamare quando tutte le chiavi sono raccolte

    private int totalKeys;     // Impostato automaticamente
    public int collectedKeys;

    //void Awake()
    //{
    //    Instance = this;
    //}

    void Start()
    {
        totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;
        Debug.Log($"Chiavi totali: {totalKeys}");
        collectedKeys = 0;
    }

    public void CollectKey()
    {
        collectedKeys++;
        Debug.Log($"Chiavi raccolte: {collectedKeys}");
        if (collectedKeys >= totalKeys)
        {
            Debug.Log("Tutte le chiavi sono state raccolte!");
            //door.Unlock();
            onAllKeysCollected?.Invoke(); // Chiama l'evento
        }
    }
}


