using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{   
    public CoinManager coinManager;

    void Start()
    {
        if (coinManager == null)
        {
            coinManager = FindObjectOfType<CoinManager>();
            if (coinManager == null)
            {
                Debug.LogError("CoinManager not found in the scene!");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Moneta raccolta!");
            coinManager.CollectCoin();
            ////CoinManager.Instance.CollectCoin();
            Destroy(gameObject);
        }
}
}
