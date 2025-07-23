using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{   
    public KeyManager keyManager;

    void Start()
    {
        if (keyManager == null)
        {
            keyManager = FindObjectOfType<KeyManager>();
            if (keyManager == null)
            {
                Debug.LogError("KeyManager not found in the scene!");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chiave raccolta!");
            keyManager.CollectKey();
            Destroy(gameObject);
        }
}
}
