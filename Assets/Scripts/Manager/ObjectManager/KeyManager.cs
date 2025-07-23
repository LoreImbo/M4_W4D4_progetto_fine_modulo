using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAllKeysCollected; // Evento da chiamare quando tutte le chiavi sono raccolte

    private int _totalKeys;
    private int _collectedKeys;

    void Start()
    {
        _totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;
        Debug.Log($"Chiavi totali da raccogliere per sbloccare la porta: {_totalKeys}");
        _collectedKeys = 0;
    }

    public void CollectKey()
    {
        _collectedKeys++;
        Debug.Log($"Chiavi raccolte: {_collectedKeys}");
        if (_collectedKeys >= _totalKeys)
        {
            Debug.Log("Tutte le chiavi sono state raccolte!");

            _onAllKeysCollected?.Invoke(); // Chiama l'evento
        }
    }
}


