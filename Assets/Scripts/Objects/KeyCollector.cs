using UnityEngine;

public class KeyCollector : MonoBehaviour
{   
    [SerializeField] private KeyManager _keyManager;

    void Start()
    {
        if (_keyManager == null)
        {
            _keyManager = FindObjectOfType<KeyManager>();
            if (_keyManager == null)
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
            _keyManager.CollectKey();
            Destroy(gameObject);
        }
}
}
